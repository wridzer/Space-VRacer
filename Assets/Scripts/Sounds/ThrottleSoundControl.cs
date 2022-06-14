using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;
using FMODUnity;

public class ThrottleSoundControl : MonoBehaviour
{
    [SerializeField] private AnimationCurve soundCurve;

    private EventInstance instance;

    private Rigidbody rb;

    int value = 1;

    private void Start()
    {
        instance = GetComponent<StudioEventEmitter>().EventInstance;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // float value = (rb.velocity.sqrMagnitude * 0.05f) * InputHandler.throttleInput;
        instance.setParameterByName("LoopPart", value);
        Debug.Log(value);

        if (Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            value++;
        }
    }

}
