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
        foreach(MovementSettingObject settings in states)
        {
            FlightState state = settings.flightState;
            state.LayerMask = maglevRaycastLayer;
            state.Movement = this;
            state.Settings = settings;
            sm.AddState(state);
        }
        sm.SwitchState(maglevRaycastLayer);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (rb.velocity.x < movementSettings.topSpeed)
            rb.AddForce(Vector3.forward * movementSettings.acceleration * Time.deltaTime, ForceMode.Force);
    }
}