using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private GameObject thrusterL, thrusterR, thrusterU, thrusterD;
    private StudioEventEmitter thrusterLEmitter, thrusterREmitter, thrusterUEmitter, thrusterDEmitter;

    [SerializeField] private GameObject engine, brake, maglevEnter, maglevExit, collission;
    private StudioEventEmitter engineEmitter, brakeEmitter, maglevEnterEmitter, maglevExitEmitter, collissionEmitter;
    private Rigidbody rb;
    [HideInInspector] public bool InMaglev;

    // Start is called before the first frame update
    void Awake()
    {
        engineEmitter      = engine.GetComponent<StudioEventEmitter>();
        brakeEmitter       = brake.GetComponent<StudioEventEmitter>();
        maglevEnterEmitter = maglevEnter.GetComponent<StudioEventEmitter>();
        maglevExitEmitter  = maglevExit.GetComponent<StudioEventEmitter>();
        collissionEmitter  = collission.GetComponent<StudioEventEmitter>();

        rb = GetComponent<Rigidbody>();

        thrusterLEmitter = thrusterL.GetComponent<StudioEventEmitter>();
        thrusterREmitter = thrusterR.GetComponent<StudioEventEmitter>();
        thrusterUEmitter = thrusterU.GetComponent<StudioEventEmitter>();
        thrusterDEmitter = thrusterD.GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        EngineSound();
    }

    private void EngineSound()
    {
        //Zero-G max Velocity: 50ish
        //Maglev max velocity: 110ish?
        //Haha hardcoding goes brr
        float engineValue;

        if(!InMaglev)
        {
            engineValue = Mathf.Clamp(rb.velocity.magnitude * 0.01f * Mathf.Abs(InputHandler.throttleInput), 0, 0.49999f); //0.01 becomes .5 when multiplied with 50
        }
        else
        {
            engineValue = Mathf.Clamp((rb.velocity.magnitude * 0.005f * Mathf.Abs(InputHandler.throttleInput)) + 0.5f, 0.5f, 1.5f); //0.005 becomes .5 when multiplied with 100

        }


        engineEmitter.EventInstance.setParameterByName("Speed", engineValue);
        if (!engineEmitter.IsPlaying()) { engineEmitter.Play(); }
    }

    public void TriggerBrake()
    {
        if (!brakeEmitter.IsPlaying()) { brakeEmitter.Play(); }
    }
    public void TriggerMaglevEnter()
    {
        maglevEnterEmitter.Play();
    }
    public void TriggerMaglevExit()
    {
        maglevExitEmitter.Play();
    }
    public void TriggerCollission(Vector3 _pos)
    {
        collission.transform.position = _pos;
        collissionEmitter.Play();
    }

    public void TriggerThruster(THRUSTERS _thuster)
    {
        switch (_thuster)
        {
            case THRUSTERS.LEFT:
                if (!thrusterLEmitter.IsPlaying()) { thrusterLEmitter.Play(); }
                break;
            case THRUSTERS.RIGHT:
                if (!thrusterREmitter.IsPlaying()) { thrusterREmitter.Play(); }
                break;
            case THRUSTERS.UP:
                if (!thrusterUEmitter.IsPlaying()) { thrusterUEmitter.Play(); }
                break;
            case THRUSTERS.DOWN:
                if (!thrusterDEmitter.IsPlaying()) { thrusterDEmitter.Play(); }
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TriggerCollission(collision.contacts[0].point);
    }

}

public enum THRUSTERS
{
    LEFT = 1,
    RIGHT = 2,
    UP = 3,
    DOWN = 4
}
