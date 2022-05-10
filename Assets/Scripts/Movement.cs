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

    private void Start()
    {
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
        // This causes stackoverflow???
        rb.AddForce(rb.transform.up * movementSettings.decoupleSpeed * Time.deltaTime, ForceMode.Force);
    }

    public void KeepAlligned()
    {
        // Maybe lerp this?
        Vector3 allignRot = new Vector3(maglevNormal.x, 0f, maglevNormal.z);
        rb.AddTorque(allignRot);
    }

    public void Rotate()
    {
        // Pitch, Yaw and Roll
        rb.AddTorque(new Vector3(0, 0, 1) * movementSettings.pitchSpeed * InputHandler.pitchInput * Time.deltaTime, ForceMode.Force);
        if (!rollMode) // If we do it like this than on contlollers where you can do both we just ignore rollmode
        {
            rb.AddTorque(new Vector3(0, 1, 0) * movementSettings.yawSpeed * InputHandler.yawInput * Time.deltaTime, ForceMode.Force);
            rb.AddTorque(new Vector3(1, 0, 0) * movementSettings.rollSpeed * InputHandler.rollInput * Time.deltaTime, ForceMode.Force);
        } else
        {
            rb.AddTorque(new Vector3(1, 0, 0) * movementSettings.rollSpeed * InputHandler.yawInput * Time.deltaTime, ForceMode.Force);
        }
    }

    public void Move()
    {
        // Throttle and Brake
        if (rb.velocity.x < movementSettings.topSpeed || rb.velocity.x > movementSettings.reverseTopSpeed)
            rb.AddForce(rb.transform.forward * movementSettings.acceleration * InputHandler.throttleInput * Time.deltaTime, ForceMode.Force);

        // Thrusters
        rb.AddForce(rb.transform.up * movementSettings.thrusterAcceleration * InputHandler.verThrusterInput * Time.deltaTime, ForceMode.Force);
        rb.AddForce(rb.transform.right * movementSettings.thrusterAcceleration * InputHandler.horThrusterInput * Time.deltaTime, ForceMode.Force);

        // Release and Rollmode
        rollMode = InputHandler.rollModeInput;
        if (InputHandler.releaseInput)
        {
            sm.SwitchState(MaskToLayerConversion(ZeroGLayer));
        }
    }

    public void DetectState()
    {
        lastTrack = currentTrack;
        RaycastHit hit;
        if (Physics.Raycast(shipInstance.transform.position, -rb.transform.up, out hit, Mathf.Infinity, trackMask))
        {
            currentTrack = hit.collider.gameObject;
            if (!lastTrack || currentTrack.layer != lastTrack.layer)
            {
                sm.SwitchState(currentTrack.layer);
                maglevNormal = hit.normal;
            }
        }
    }
}