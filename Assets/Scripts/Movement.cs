using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private List<MovementSettingObject> states = new List<MovementSettingObject>();

    [SerializeField] private LayerMask ZeroGLayer;
    [SerializeField] private LayerMask trackMask;

    [SerializeField] private GameObject shipInstance;

    [HideInInspector] public MovementSettingObject movementSettings;
    [HideInInspector] public Rigidbody rb;
    private StateMachine sm;
    private bool rollMode;

    // For getting track
    private GameObject lastTrack, currentTrack;
    private Vector3 maglevNormal;
    [HideInInspector] public Quaternion myRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        rollMode = false;
        rb = GetComponent<Rigidbody>();
        sm = new StateMachine();
        InputHandler.Subscribe();
        foreach(MovementSettingObject settings in states)
        {
            FlightState state = GetState(settings);
            sm.AddState(state);
        }
        DetectState();
        myRotation = rb.rotation;
    }

    private FlightState GetState(MovementSettingObject _settings)
    {
        int layerNumber = MaskToLayerConversion(_settings.layerMask);

        switch (_settings.flightStates)
        {
            case FlightStates.Maglev: return new MaglevState(_settings, this, layerNumber);
            case FlightStates.ZeroG: return new ZeroGState(_settings, this, layerNumber);
        }

        return null;
    }

    private int MaskToLayerConversion(LayerMask _Mask)
    {
        // Bitmagic I copied from internet lol
        int layerNumber = 0;
        int layer = _Mask.value;
        while (layer > 0)
        {
            layer = layer >> 1;
            layerNumber++;
        }
        layerNumber--;
        return layerNumber;
    }

    private void FixedUpdate()
    {
        sm.Update();
    }

    public void Decouple()
    {
        rb.AddForce(rb.transform.up * movementSettings.decoupleSpeed, ForceMode.Force);
    }

    public void KeepAlligned()
    {
        // Maybe lerp this?
        //Quaternion targetPlane = Quaternion.FromToRotation(Vector3.up, maglevNormal);
        //rb.rotation = Quaternion.FromToRotation(Vector3.right, maglevNormal);

        // targetNormal = hit.normal;
        //var fromRotation = rb.rotation;
        //var ajustedMaglev = maglevNormal + new Vector3(0, myRotation.eulerAngles.y, 0);
        //var toRotation = Quaternion.Euler(ajustedMaglev);
        //rb.MoveRotation(Quaternion.Slerp(fromRotation, toRotation, movementSettings.maglevStrength));

        // rb.transform.up = new Vector3(maglevNormal.x, myRotation.eulerAngles.y, maglevNormal.z);

        // de rb.Rotation moet de x en z naar de maglevnormal bewegen terwijl de y niet wordt aangetast

        // rb.AddTorque(new Vector3(maglevNormal.x - rb.transform.localEulerAngles.x, 0, maglevNormal.z - rb.transform.localEulerAngles.z) * movementSettings.maglevStrength, ForceMode.Force);
        myRotation.eulerAngles += new Vector3(maglevNormal.x - rb.rotation.x, 0, maglevNormal.z - rb.rotation.z) * movementSettings.maglevStrength;
    }

    public void Rotate()
    {
        // Pitch, Yaw and Roll
        myRotation.eulerAngles += new Vector3(1, 0, 0) * movementSettings.pitchSpeed * InputHandler.pitchInput;
        if (!rollMode) // If we do it like this than on contlollers where you can do both we just ignore rollmode
        {
            myRotation.eulerAngles += new Vector3(0, 1, 0) * movementSettings.yawSpeed * InputHandler.yawInput;
            myRotation.eulerAngles += new Vector3(0, 0, 1) * movementSettings.rollSpeed * InputHandler.rollInput;
        } else
        {
            myRotation.eulerAngles += new Vector3(0, 1, 0) * movementSettings.rollSpeed * InputHandler.yawInput;
        }

        rb.MoveRotation(Quaternion.Slerp(rb.rotation, myRotation, movementSettings.totalRotationSpeed));

    }

    public void Move()
    {
        // Throttle and Brake
        if (rb.velocity.x < movementSettings.topSpeed || rb.velocity.x > movementSettings.reverseTopSpeed)
            rb.AddForce(rb.transform.forward * movementSettings.acceleration * InputHandler.throttleInput, ForceMode.Force);

        // Thrusters
        rb.AddForce(rb.transform.up * movementSettings.thrusterAcceleration * InputHandler.verThrusterInput, ForceMode.Force);
        rb.AddForce(rb.transform.right * movementSettings.thrusterAcceleration * InputHandler.horThrusterInput, ForceMode.Force);

        // Release and Rollmode
        rollMode = InputHandler.rollModeInput;
    }

    public void DetectState()
    {
        if (lastTrack != null)
        {
            lastTrack = currentTrack;
        }

        RaycastHit hit;
        if (Physics.Raycast(shipInstance.transform.position, -rb.transform.up, out hit, Mathf.Infinity, trackMask))
        {
            currentTrack = hit.collider.gameObject;
            maglevNormal = hit.normal;

            if (InputHandler.releaseInput)
            {
                lastTrack = null;
                int zeroGLayer = MaskToLayerConversion(ZeroGLayer);
                sm.SwitchState(zeroGLayer);
                if (currentTrack.layer == zeroGLayer) // Set release back for jumps
                {
                    InputHandler.releaseInput = false;
                }
            }
            else
            {
                if (!lastTrack || currentTrack.layer != lastTrack.layer) // Only switch state on new track type
                {
                    sm.SwitchState(currentTrack.layer);
                }
            }
        }
    }
}