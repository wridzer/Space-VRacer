using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private List<MovementSettingObject> states = new List<MovementSettingObject>();

    [HideInInspector] public MovementSettingObject movementSettings;

    [SerializeField] private LayerMask maglevRaycastLayer;
    private Rigidbody rb;
    private Quaternion myRotation;
    private StateMachine sm;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sm = new StateMachine();
        InputHandler.Subscribe();
        foreach(MovementSettingObject settings in states)
        {
            FlightState state = GetState(settings);
            sm.AddState(state);
        }
        sm.SwitchState(maglevRaycastLayer);
    }

    private FlightState GetState(MovementSettingObject _settings)
    {
        switch (_settings.flightStates)
        {
            case FlightStates.Maglev: return new MaglevState(_settings, this, _settings.layerMask);
                //case FlightStates.ZeroG: return new 
        }

        return null;
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        if (rb.velocity.x < movementSettings.topSpeed)
            rb.AddForce(rb.transform.forward * movementSettings.acceleration * InputHandler.throttleInput * Time.deltaTime, ForceMode.Force);
        rb.AddTorque(new Vector3(0, 0, 1) * movementSettings.pitchSpeed * InputHandler.pitchInput * Time.deltaTime, ForceMode.Force);
        rb.AddTorque(new Vector3(0, 1, 0) * movementSettings.yawSpeed * InputHandler.yawInput * Time.deltaTime, ForceMode.Force);
        rb.AddTorque(new Vector3(1, 0, 0) * movementSettings.rollSpeed * InputHandler.rollInput * Time.deltaTime, ForceMode.Force);
        rb.AddForce(rb.transform.up * movementSettings.thrusterAcceleration * InputHandler.verThrusterInput * Time.deltaTime, ForceMode.Force);
        rb.AddForce(rb.transform.right * movementSettings.thrusterAcceleration * InputHandler.horThrusterInput * Time.deltaTime, ForceMode.Force);

        //in rollmode rb.freezerotation.z or something like that
    }

    private void DetectState()
    {
        //do a raycast to get layermask, then sm.SwitchState(layermask);
    }
}