using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputHandler
{
    public static float throttleInput { get; private set; }
    public static float horThrusterInput { get; private set; }
    public static float verThrusterInput { get; private set; }
    public static float pitchInput { get; private set; }
    public static float yawInput { get; private set; }
    public static float rollInput { get; private set; }
    public static bool releaseInput { get; set; } = false;
    public static bool rollModeInput { get; private set; }

    private static ShipControls input = new ShipControls();


    public static void Subscribe()
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

    #region input
    static void OnThrustersLR(InputAction.CallbackContext context)
    {
        horThrusterInput = context.ReadValue<float>();
    }
    static void OnThrustersUD(InputAction.CallbackContext context)
    {
        verThrusterInput = context.ReadValue<float>();
    }
    static void OnYaw(InputAction.CallbackContext context)
    {
        yawInput = context.ReadValue<float>();
    }
    static void OnPitch(InputAction.CallbackContext context)
    {
        pitchInput = context.ReadValue<float>();
    }
    static void OnRoll(InputAction.CallbackContext context)
    {
        //Added a quadratic component to make precision rolling at low input values more viable while also allowing fast snap rolling
        //NOTE: This absolutely breaks when rollInput is not normalized
        rollInput = Mathf.Pow(context.ReadValue<float>(), 1.5f);
    }
    static void OnRelease(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0.5f) { releaseInput = !releaseInput;}
    }
    static void OnRollmode(InputAction.CallbackContext context)
    {
        rollModeInput = context.ReadValue<float>() > 0.5f;
    }
    static void OnThrottleBrake(InputAction.CallbackContext context)
    {
        throttleInput = context.ReadValue<float>();
    }
    #endregion
}