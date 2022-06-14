//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Controls and Input/ShipControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ShipControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShipControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShipControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""2cf5c500-48ef-4b0d-875d-22cda96e613a"",
            ""actions"": [
                {
                    ""name"": ""Thrusters LR"",
                    ""type"": ""Value"",
                    ""id"": ""7d351b98-21ed-4ffd-81c5-8b65580ee43a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Thrusters UD"",
                    ""type"": ""Value"",
                    ""id"": ""8b099c58-4e8e-4787-858c-19084536eabe"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Yaw"",
                    ""type"": ""Value"",
                    ""id"": ""6b4cda39-1f37-4759-bd5d-81cabfac4ef1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pitch"",
                    ""type"": ""Value"",
                    ""id"": ""1dfdd796-8ba8-497e-b3a7-4bba37ee9558"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Value"",
                    ""id"": ""de98e9cb-714b-4ba4-a5ff-196364bdcbb4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Release"",
                    ""type"": ""Button"",
                    ""id"": ""ff5e6748-216a-4afc-ad35-4cad2ad27e76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rollmode"",
                    ""type"": ""Button"",
                    ""id"": ""858ce37b-865a-4eab-b710-5da02ad8f3fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throttle/Brake"",
                    ""type"": ""Value"",
                    ""id"": ""6800c59c-c13d-4933-8143-7660d9ef970b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""8a7641ca-906d-463d-a562-b5441594cc06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""45f50e53-b101-4d5a-b4b1-17147e3f32be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SongSelect"",
                    ""type"": ""Button"",
                    ""id"": ""75ca737c-6ea0-45e3-8c2c-96e680d43da4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""d48bd6df-389d-4e9f-8afe-5cafd20f47b8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrusters LR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""806039b6-00ca-4959-b49b-26816f6c840f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrusters LR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fbc04157-c680-4fbb-993f-007b02f86c4e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrusters LR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""12326c23-9bdb-4869-8a86-69642c504085"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrusters LR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""792cf42b-30ee-4cb6-982f-1869948d6d2a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Controls"",
                    ""action"": ""Thrusters LR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""84cf3cf3-5993-4258-be02-c23f7876d5d7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Controls"",
                    ""action"": ""Thrusters LR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""6ff1af0b-5c7e-4dbb-9562-f941ec20ddec"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrusters UD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ab685424-f08a-4205-9605-d4b7ea2ff7ea"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrusters UD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""95231bd0-a19b-4297-b213-72a8b9227c20"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrusters UD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""6ec3f909-b346-4c43-8f1d-b2bd465922af"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrusters UD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5f7662bf-8d3a-4c63-9d7b-f2a42fe01983"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Controls"",
                    ""action"": ""Thrusters UD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""594649f0-b8e9-47db-86da-9f2aaaf400b8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Controls"",
                    ""action"": ""Thrusters UD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""384bcee8-bea2-4758-ac94-c00d2bc1f195"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""51924377-0b60-45bb-93ac-c9c47aee1eaf"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ac25c706-b249-4df9-99d7-3398d0a25d11"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""a7100666-8a41-4aa2-8ed2-af6fb7251b70"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4183e0a6-c5d0-4c98-b598-b42846e79f1c"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""318889c3-7b28-4e6b-bb0f-e5f427857f37"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e4bd4828-8c2a-4b6a-a1be-80c419e532f6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0d6b238-187a-4787-bbfb-d12e0d63ce2a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a0db852-374c-4537-a210-b2478b1b9a68"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Controls"",
                    ""action"": ""Rollmode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8b8f552-e6bf-48dc-9a62-214707d29a18"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad only;Main Controls"",
                    ""action"": ""Rollmode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f942b72f-103b-4749-8760-46ad4ebec783"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad only;Main Controls"",
                    ""action"": ""Rollmode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ea648e11-dd23-402e-8b91-4ab470ac2dbc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle/Brake"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7150528c-e12a-4948-b82b-4a7810beed19"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle/Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""37c33a52-0d10-4b9b-b75f-6c0351fbef5a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle/Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""8bf95ce2-2aa3-4a28-a170-2750f4f2bb66"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle/Brake"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""62248bd0-e532-4398-bbbc-529cdd32716b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle/Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9216d1bc-0ecb-44df-94d3-73cb72e9d870"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle/Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0376ecb9-6c61-480b-8007-fc185fbaf216"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21021d10-2092-48fd-9610-fd10f0d480bc"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5faba6c2-7892-46a6-b73e-3f95764547c7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Controls;Gamepad only"",
                    ""action"": ""SongSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Main Controls"",
            ""bindingGroup"": ""Main Controls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad only"",
            ""bindingGroup"": ""Gamepad only"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_ThrustersLR = m_Movement.FindAction("Thrusters LR", throwIfNotFound: true);
        m_Movement_ThrustersUD = m_Movement.FindAction("Thrusters UD", throwIfNotFound: true);
        m_Movement_Yaw = m_Movement.FindAction("Yaw", throwIfNotFound: true);
        m_Movement_Pitch = m_Movement.FindAction("Pitch", throwIfNotFound: true);
        m_Movement_Roll = m_Movement.FindAction("Roll", throwIfNotFound: true);
        m_Movement_Release = m_Movement.FindAction("Release", throwIfNotFound: true);
        m_Movement_Rollmode = m_Movement.FindAction("Rollmode", throwIfNotFound: true);
        m_Movement_ThrottleBrake = m_Movement.FindAction("Throttle/Brake", throwIfNotFound: true);
        m_Movement_Restart = m_Movement.FindAction("Restart", throwIfNotFound: true);
        m_Movement_Reset = m_Movement.FindAction("Reset", throwIfNotFound: true);
        m_Movement_SongSelect = m_Movement.FindAction("SongSelect", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_ThrustersLR;
    private readonly InputAction m_Movement_ThrustersUD;
    private readonly InputAction m_Movement_Yaw;
    private readonly InputAction m_Movement_Pitch;
    private readonly InputAction m_Movement_Roll;
    private readonly InputAction m_Movement_Release;
    private readonly InputAction m_Movement_Rollmode;
    private readonly InputAction m_Movement_ThrottleBrake;
    private readonly InputAction m_Movement_Restart;
    private readonly InputAction m_Movement_Reset;
    private readonly InputAction m_Movement_SongSelect;
    public struct MovementActions
    {
        private @ShipControls m_Wrapper;
        public MovementActions(@ShipControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ThrustersLR => m_Wrapper.m_Movement_ThrustersLR;
        public InputAction @ThrustersUD => m_Wrapper.m_Movement_ThrustersUD;
        public InputAction @Yaw => m_Wrapper.m_Movement_Yaw;
        public InputAction @Pitch => m_Wrapper.m_Movement_Pitch;
        public InputAction @Roll => m_Wrapper.m_Movement_Roll;
        public InputAction @Release => m_Wrapper.m_Movement_Release;
        public InputAction @Rollmode => m_Wrapper.m_Movement_Rollmode;
        public InputAction @ThrottleBrake => m_Wrapper.m_Movement_ThrottleBrake;
        public InputAction @Restart => m_Wrapper.m_Movement_Restart;
        public InputAction @Reset => m_Wrapper.m_Movement_Reset;
        public InputAction @SongSelect => m_Wrapper.m_Movement_SongSelect;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @ThrustersLR.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrustersLR;
                @ThrustersLR.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrustersLR;
                @ThrustersLR.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrustersLR;
                @ThrustersUD.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrustersUD;
                @ThrustersUD.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrustersUD;
                @ThrustersUD.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrustersUD;
                @Yaw.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnYaw;
                @Yaw.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnYaw;
                @Yaw.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnYaw;
                @Pitch.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnPitch;
                @Pitch.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnPitch;
                @Pitch.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnPitch;
                @Roll.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRoll;
                @Release.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRelease;
                @Release.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRelease;
                @Release.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRelease;
                @Rollmode.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRollmode;
                @Rollmode.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRollmode;
                @Rollmode.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRollmode;
                @ThrottleBrake.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrottleBrake;
                @ThrottleBrake.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrottleBrake;
                @ThrottleBrake.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrottleBrake;
                @Restart.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRestart;
                @Reset.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnReset;
                @SongSelect.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnSongSelect;
                @SongSelect.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnSongSelect;
                @SongSelect.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnSongSelect;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ThrustersLR.started += instance.OnThrustersLR;
                @ThrustersLR.performed += instance.OnThrustersLR;
                @ThrustersLR.canceled += instance.OnThrustersLR;
                @ThrustersUD.started += instance.OnThrustersUD;
                @ThrustersUD.performed += instance.OnThrustersUD;
                @ThrustersUD.canceled += instance.OnThrustersUD;
                @Yaw.started += instance.OnYaw;
                @Yaw.performed += instance.OnYaw;
                @Yaw.canceled += instance.OnYaw;
                @Pitch.started += instance.OnPitch;
                @Pitch.performed += instance.OnPitch;
                @Pitch.canceled += instance.OnPitch;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Release.started += instance.OnRelease;
                @Release.performed += instance.OnRelease;
                @Release.canceled += instance.OnRelease;
                @Rollmode.started += instance.OnRollmode;
                @Rollmode.performed += instance.OnRollmode;
                @Rollmode.canceled += instance.OnRollmode;
                @ThrottleBrake.started += instance.OnThrottleBrake;
                @ThrottleBrake.performed += instance.OnThrottleBrake;
                @ThrottleBrake.canceled += instance.OnThrottleBrake;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
                @SongSelect.started += instance.OnSongSelect;
                @SongSelect.performed += instance.OnSongSelect;
                @SongSelect.canceled += instance.OnSongSelect;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    private int m_MainControlsSchemeIndex = -1;
    public InputControlScheme MainControlsScheme
    {
        get
        {
            if (m_MainControlsSchemeIndex == -1) m_MainControlsSchemeIndex = asset.FindControlSchemeIndex("Main Controls");
            return asset.controlSchemes[m_MainControlsSchemeIndex];
        }
    }
    private int m_GamepadonlySchemeIndex = -1;
    public InputControlScheme GamepadonlyScheme
    {
        get
        {
            if (m_GamepadonlySchemeIndex == -1) m_GamepadonlySchemeIndex = asset.FindControlSchemeIndex("Gamepad only");
            return asset.controlSchemes[m_GamepadonlySchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnThrustersLR(InputAction.CallbackContext context);
        void OnThrustersUD(InputAction.CallbackContext context);
        void OnYaw(InputAction.CallbackContext context);
        void OnPitch(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnRelease(InputAction.CallbackContext context);
        void OnRollmode(InputAction.CallbackContext context);
        void OnThrottleBrake(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnSongSelect(InputAction.CallbackContext context);
    }
}
