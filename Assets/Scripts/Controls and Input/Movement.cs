using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private List<MovementSettingObject> states = new List<MovementSettingObject>();

    [SerializeField] private LayerMask ZeroGLayer;
    [SerializeField] private LayerMask trackMask;

    [SerializeField] private GameObject shipInstance, trackDetect;

    [HideInInspector] public MovementSettingObject movementSettings;
    [HideInInspector] public Rigidbody rb;
    private StateMachine sm;
    private bool rollMode;

    // For getting track
    private GameObject lastTrack, currentTrack;
    private Vector3 maglevNormal;
    private Vector3 deltaRot;
    private float distanceToTrack;

    [HideInInspector] public float localYRot;
    [HideInInspector] public Vector3 deltaMagRot;

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
        deltaRot = Vector3.zero;
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

    public void Decouple() // from maglev
    {
        rb.AddForce(rb.transform.up * movementSettings.decoupleSpeed, ForceMode.Force);
    }

    public void KeepAlligned() // on maglev
    {
        // Rotation (thanks to Valentijn for this math <3)
        Vector3 cross = Vector3.Cross(rb.transform.forward, maglevNormal);
        Vector3 projectOnPlane = Vector3.Cross(maglevNormal, cross);
        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(projectOnPlane, maglevNormal), Time.fixedDeltaTime * movementSettings.maglevRotStrength);

        // Distance
        float distantForce = movementSettings.maglevDistance - distanceToTrack; // this makes the force greater when closer/futher from desired distance
        if(distantForce > 0)
        {
            rb.AddForce(rb.transform.up * movementSettings.maglevDisStrength * (distantForce * movementSettings.maglevDistanceMultiplier), ForceMode.Force);
        }
        if (distantForce < 0)
        {
            rb.AddForce(-rb.transform.up * movementSettings.maglevDisStrength * (-distantForce * movementSettings.maglevDistanceMultiplier), ForceMode.Force);
        }
    }

    public void Rotate()
    {
        // Pitch, Yaw and Roll
        deltaRot += new Vector3(1, 0, 0) * movementSettings.pitchSpeed * InputHandler.pitchInput;
        if (!rollMode) // If we do it like this than on contlollers where you can do both we just ignore rollmode
        {
            deltaRot += new Vector3(0, 1, 0) * movementSettings.yawSpeed * InputHandler.yawInput;
            deltaRot += new Vector3(0, 0, 1) * movementSettings.rollSpeed * InputHandler.rollInput;
        } else
        {
            deltaRot += new Vector3(0, 1, 0) * movementSettings.rollSpeed * InputHandler.yawInput;
        }

        Quaternion deltaRotation = Quaternion.Euler(deltaRot * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        deltaRot = Vector3.zero;

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

        Vector3 shipForwardOffset = new Vector3(0, shipInstance.transform.localScale.y * 0.5f, 0); // To raycast from frontend of the ship
        Vector3 raycastOffset = (trackDetect.transform.position - shipInstance.transform.position).normalized; // To raycast towards the trackdetector, to point forwards

        if (Physics.Raycast(shipInstance.transform.position + shipForwardOffset, raycastOffset, out hit, Mathf.Infinity, trackMask))
        {
            currentTrack = hit.collider.gameObject;
            maglevNormal = hit.normal;
            distanceToTrack = hit.distance;

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