using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    // , UI, music, start
    // DONE: Throttle, thruster, brake, maglev enter, collission, checkpoint, finish
    [SerializeField] private GameObject thrusterL, thrusterR, thrusterU, thrusterD;
    private EventInstance thrusterLInstance, thrusterRInstance, thrusterUInstance, thrusterDInstance;

    [SerializeField] private GameObject engine, brake, maglevEnter, maglevExit, collission;
    private EventInstance engineInstance, brakeInstance, maglevEnterInstance, maglevExitInstance, collissionInstance;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        engineInstance      = GetComponent<StudioEventEmitter>().EventInstance;
        brakeInstance       = GetComponent<StudioEventEmitter>().EventInstance;
        maglevEnterInstance = GetComponent<StudioEventEmitter>().EventInstance;
        maglevExitInstance  = GetComponent<StudioEventEmitter>().EventInstance;
        collissionInstance  = GetComponent<StudioEventEmitter>().EventInstance;

        rb = GetComponent<Rigidbody>();

        thrusterLInstance = thrusterL.GetComponent<StudioEventEmitter>().EventInstance;
        thrusterRInstance = thrusterR.GetComponent<StudioEventEmitter>().EventInstance;
        thrusterUInstance = thrusterU.GetComponent<StudioEventEmitter>().EventInstance;
        thrusterDInstance = thrusterD.GetComponent<StudioEventEmitter>().EventInstance;
    }

    // Update is called once per frame
    void Update()
    {
        EngineSound();
    }

    private void EngineSound()
    {
        float engineValue = (rb.velocity.sqrMagnitude * 0.05f) * InputHandler.throttleInput;
        engineInstance.setParameterByName("Speed", engineValue);
    }

    public void TriggerBrake()
    {
        brakeInstance.start();
    }
    public void TriggerMaglevEnter()
    {
        maglevEnterInstance.start();
    }
    public void TriggerMaglevExit()
    {
        maglevExitInstance.start();
    }
    public void TriggerCollission(Vector3 _pos)
    {
        collission.transform.position = _pos;
        collissionInstance.start();
    }

    public void TriggerThruster(THRUSTERS _thuster)
    {
        switch (_thuster)
        {
            case THRUSTERS.LEFT:
                thrusterLInstance.start();
                break;
            case THRUSTERS.RIGHT:
                thrusterRInstance.start();
                break;
            case THRUSTERS.UP:
                thrusterUInstance.start();
                break;
            case THRUSTERS.DOWN:
                thrusterDInstance.start();
                break;
        }
    }

}

public enum THRUSTERS
{
    LEFT = 1,
    RIGHT = 2,
    UP = 3,
    DOWN = 4
}
