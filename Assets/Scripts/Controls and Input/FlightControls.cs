using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlightControls : MonoBehaviour
{
    /*How I want the controls to behave:

     * There's no newtonian physics, even though we're in zero-G. Because arcade. Sorry Emi.
     * Take all velocities seperately, then combine them for a final velocity and set rb.velocity to that directly?

     * Engine velocity always points towards transform.forward, and rotates with you when cornering. 
        * It does have acceleration and deceleration, and a top speed, which takes a while to reach
        * Should rotation affect this speed. Maybe? Not sure how. Welp.
            * Okay but like, what if it doesn't? Might just work out fine.

     * Thrusters velocity has no acceleration and deceleration, but has a speed equal to input

     * When on Maglev, your ship's rotation aligns with the X/Z plane of the maglev track
     * When on Maglev, Engine acceleration, deceleration, and top speed all increase
        * If we put in speed boosters, they increase acceleration and top speed even more?
     * When in Maglev range, your ship gets pulled down to the track with a constant velocity, and pushed up with a velocity based on distance
        * This should basically put the ship on a specific height, but that height is slightly variable with up/down thrust

     * When pressing Release, ignore the maglev track. 
        * When pressing Release with up thrust, the maglev down velocity becomes an up velocity, making you jump
    */

    [Header("Maglev values")]
    [SerializeField] private LayerMask maglevRaycastLayer;
    [SerializeField] private float maglevRotationSpeed;
    [SerializeField] private float maglevEngineMultiplier, maglevDownVelocity, maglevUpVelocityMultiplier, currentMaglevVelocity, maglevRange;

    [Header("Velocity and Acceleration")]
    [SerializeField] private float engineVelocity;
    [SerializeField] private float maxEngineVelocity, minEngineVelocity, maxAccelerationBase, maxDecelerationBase, overSpeedAcceleration;

    [Header("Min Max Speed")]
    [SerializeField] private float currentForwardTopSpeed;
    [SerializeField] private float currentBackTopSpeed, currentMaxAcceleration, currentMaxDeceleration;

    [Header("Control Speed")]
    [SerializeField] private float thrusterPower;
    [SerializeField] private float pitchSpeed, yawSpeed, rollSpeed, pitchSpeedBase, rollSpeedBase;

    private float throttleInput, horThrusterInput, verThrusterInput, pitchInput, yawInput, rollInput;
    private bool releaseInput;

    private ShipControls input;
    private Vector3 thrusterVelocity, maglevVelocity;
    private bool maglevActive, inMaglev, rollMode;

    private Rigidbody rb;
    private Quaternion myRotation;

    private void Awake()
    {
        input = new ShipControls();
    }

    private void OnDisable()
    {
        input?.Disable();

        #region unsubscribing
        input.Movement.ThrustersLR.started -= OnThrustersLR;
        input.Movement.ThrustersLR.performed -= OnThrustersLR;
        input.Movement.ThrustersLR.canceled -= OnThrustersLR;

        input.Movement.ThrustersUD.started -= OnThrustersUD;
        input.Movement.ThrustersUD.performed -= OnThrustersUD;
        input.Movement.ThrustersUD.canceled -= OnThrustersUD;

        input.Movement.Yaw.started -= OnYaw;
        input.Movement.Yaw.performed -= OnYaw;
        input.Movement.Yaw.canceled -= OnYaw;

        input.Movement.Pitch.started -= OnPitch;
        input.Movement.Pitch.performed -= OnPitch;
        input.Movement.Pitch.canceled -= OnPitch;

        input.Movement.Roll.started -= OnRoll;
        input.Movement.Roll.performed -= OnRoll;
        input.Movement.Roll.canceled -= OnRoll;

        input.Movement.Release.started -= OnRelease;
        input.Movement.Release.performed -= OnRelease;
        input.Movement.Release.canceled -= OnRelease;

        input.Movement.Rollmode.started -= OnRollmode;
        input.Movement.Rollmode.performed -= OnRollmode;
        input.Movement.Rollmode.canceled -= OnRollmode;

        input.Movement.ThrottleBrake.started -= OnThrottleBrake;
        input.Movement.ThrottleBrake.performed -= OnThrottleBrake;
        input.Movement.ThrottleBrake.canceled -= OnThrottleBrake;
        #endregion
    }

    private void OnEnable()
    {
        input?.Enable();

        #region subscribing
        input.Movement.ThrustersLR.started += OnThrustersLR;
        input.Movement.ThrustersLR.performed += OnThrustersLR;
        input.Movement.ThrustersLR.canceled += OnThrustersLR;

        input.Movement.ThrustersUD.started += OnThrustersUD;
        input.Movement.ThrustersUD.performed += OnThrustersUD;
        input.Movement.ThrustersUD.canceled += OnThrustersUD;

        input.Movement.Yaw.started += OnYaw;
        input.Movement.Yaw.performed += OnYaw;
        input.Movement.Yaw.canceled += OnYaw;

        input.Movement.Pitch.started += OnPitch;
        input.Movement.Pitch.performed += OnPitch;
        input.Movement.Pitch.canceled += OnPitch;

        input.Movement.Roll.started += OnRoll;
        input.Movement.Roll.performed += OnRoll;
        input.Movement.Roll.canceled += OnRoll;

        input.Movement.Release.started += OnRelease;
        input.Movement.Release.performed += OnRelease;
        input.Movement.Release.canceled += OnRelease;

        input.Movement.Rollmode.started += OnRollmode;
        input.Movement.Rollmode.performed += OnRollmode;
        input.Movement.Rollmode.canceled += OnRollmode;

        input.Movement.ThrottleBrake.started += OnThrottleBrake;
        input.Movement.ThrottleBrake.performed += OnThrottleBrake;
        input.Movement.ThrottleBrake.canceled += OnThrottleBrake;
        #endregion
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (overSpeedAcceleration < maxAccelerationBase || overSpeedAcceleration < maxDecelerationBase) { Debug.LogWarning("Top speed settings invalid"); }

        myRotation = transform.rotation;
    }

    #region input
    void OnThrustersLR(InputAction.CallbackContext context)
    {
        horThrusterInput = context.ReadValue<float>();
    }
    void OnThrustersUD(InputAction.CallbackContext context)
    {
        verThrusterInput = context.ReadValue<float>();
    }
    void OnYaw(InputAction.CallbackContext context)
    {
        if (!rollMode) { yawInput = context.ReadValue<float>(); } else { rollInput = context.ReadValue<float>(); }
    }
    void OnPitch(InputAction.CallbackContext context)
    {
        pitchInput = context.ReadValue<float>();
    }
    void OnRoll(InputAction.CallbackContext context)
    {
        rollInput = context.ReadValue<float>();
    }
    void OnRelease(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() < 0.5f) { maglevActive = true; } else { maglevActive = false; }

        if (context.ReadValue<float>() < 0.5f && inMaglev)
        {
            myRotation = Quaternion.Euler(0, myRotation.eulerAngles.y, 0);
        }
    }
    void OnRollmode(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0.5f) { rollMode = !rollMode; }
    }
    void OnThrottleBrake(InputAction.CallbackContext context)
    {
        throttleInput = context.ReadValue<float>();
    }
    #endregion

    private void FixedUpdate()
    {
        //Switch values if on or off maglev
        float speed, accelaration;

        //Thusters

        //Throttle and Brake

        //Roll
        
        //Pitch

        //Yaw

        //Release

        //Rollmode
    }

}