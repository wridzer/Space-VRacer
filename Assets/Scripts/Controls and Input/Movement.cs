using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    [SerializeField] private List<MovementSettingObject> states = new List<MovementSettingObject>();

    [SerializeField] private LayerMask ZeroGLayer;
    [SerializeField] private LayerMask trackMask;

    [SerializeField] private GameObject shipInstance, trackDetectState, raycastOrigin, trackDetectAllign; 
    [SerializeField] private pitchRollSliders chair;
    [SerializeField] private Slider speedOMeter;

    [HideInInspector] public MovementSettingObject movementSettings;
    [HideInInspector] public Rigidbody rb;
    private StateMachine sm;
    private bool rollMode;

    [HideInInspector] public AudioHandler audioH;


    // For getting track
    private GameObject lastTrack, currentTrack;
    private Vector3 maglevNormal;
    private Vector3 deltaRot;
    private float distanceToTrack;

    [HideInInspector] public float localYRot;
    [HideInInspector] public Vector3 deltaMagRot;

    private void Start()
    {
        audioH = GetComponent<AudioHandler>();
        // Cursor.lockState = CursorLockMode.Confined;
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
        speedOMeter.value = rb.velocity.magnitude * 0.01f;
    }

    public void Decouple() // from maglev
    {
        rb.AddForce(rb.transform.up * movementSettings.decoupleSpeed, ForceMode.Force);
    }

    public void KeepAligned() // on maglev
    {
        RaycastHit hit;
        Vector3 raycastOffset = (trackDetectAllign.transform.position - raycastOrigin.transform.position).normalized; // To raycast towards the trackdetector, to point forwards

        if (Physics.Raycast(raycastOrigin.transform.position, raycastOffset, out hit, Mathf.Infinity, trackMask))
        {
            var AllignNormal = hit.normal;

            // Rotation (thanks to Valentijn for this math <3)
            Vector3 cross = Vector3.Cross(rb.transform.forward, AllignNormal);
            Vector3 projectOnPlane = Vector3.Cross(AllignNormal, cross);
            Quaternion oldRot = rb.rotation;            
            float rotSpeed;

            //Naive implementation of snap smoothing. Might want to look into a (quadratic/exponential?) lerp later.
            /* if(Quaternion.Angle(oldRot, Quaternion.LookRotation(projectOnPlane, AllignNormal)) < movementSettings.maglevSnapAngle)
            {
                rotSpeed = movementSettings.maglevRotStrengthSnap;
            }
            else { rotSpeed = movementSettings.maglevRotStrengthRot; } */

            //Implementation using linear Lerp. Doesn't feel great, better than the naive implementation. Uses snap angle for lerp.
            //float t = 1.0f - Mathf.Min((Quaternion.Angle(oldRot, Quaternion.LookRotation(projectOnPlane, AllignNormal)) / movementSettings.maglevSnapAngle), 1.0f);
            //rotSpeed = Mathf.Lerp(movementSettings.maglevRotStrengthRot, movementSettings.maglevRotStrengthSnap, t);

            float t = 1.0f - Mathf.Min((Quaternion.Angle(oldRot, Quaternion.LookRotation(projectOnPlane, AllignNormal)) / movementSettings.maglevSnapAngle), 1.0f);
            rotSpeed = Mathf.Max(movementSettings.maglevRotStrengthMin, movementSettings.maglevRotStrength.Evaluate(t) * movementSettings.maglevRotStrengthMax);

            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(projectOnPlane, AllignNormal), Time.fixedDeltaTime * rotSpeed);
            rb.velocity = (rb.rotation * Quaternion.Inverse(oldRot)) * rb.velocity;
        } else
        {
            Vector3 cross = Vector3.Cross(rb.transform.forward, maglevNormal);
            Vector3 projectOnPlane = Vector3.Cross(maglevNormal, cross);
            //rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(projectOnPlane, maglevNormal), Time.fixedDeltaTime * movementSettings.maglevRotStrengthSnap);
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(projectOnPlane, maglevNormal), Time.fixedDeltaTime * movementSettings.maglevRotStrength.Evaluate(1.0f));
        }


        // Distance
        float distantForce = movementSettings.maglevDistance - distanceToTrack; // This makes the force greater when closer/futher from desired distance
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
        deltaRot += new Vector3(1, 0, 0) * movementSettings.pitchSpeed * -InputHandler.pitchInput;
        if (!rollMode) // If we do it like this than on controllers where you can do both we just ignore rollmode
        {
            deltaRot += new Vector3(0, 1, 0) * movementSettings.yawSpeed * InputHandler.yawInput;
            deltaRot += new Vector3(0, 0, -1) * movementSettings.rollSpeed * InputHandler.rollInput;
        } else
        {
            deltaRot += new Vector3(0, 0, -1) * movementSettings.rollSpeed * InputHandler.yawInput;
        }

        if (chair != null)
        {
            chair.localAngularVelocity = deltaRot;
        }

        Quaternion deltaRotation = Quaternion.Euler(deltaRot * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        deltaRot = Vector3.zero;

    }

    public void Move()
    {
        // Mana wanted drag, WELL HERE YOU FUCKING GO

        float accelerationX = 0, accelerationY = 0, accelerationZ = 0;

        accelerationX = movementSettings.horizontalThrusterAcceleration * -InputHandler.horThrusterInput;
        accelerationY = movementSettings.verticalThrusterAcceleration * -InputHandler.verThrusterInput;
        accelerationZ = movementSettings.acceleration * -InputHandler.throttleInput;

        // velocity = (1/drag coefficient) * (e^-dragC/m*ΔT)*(dragC*velocity+mass*a)-(mass*a/dragC)
        float velocityX = (1f / movementSettings.frictionCoefX) * (Mathf.Pow(2.71828f, -movementSettings.frictionCoefX / rb.mass * Time.fixedDeltaTime)) *
            (movementSettings.frictionCoefX * transform.InverseTransformDirection(rb.velocity).x + rb.mass * accelerationX) - (rb.mass * accelerationX / movementSettings.frictionCoefX);
        float velocityY = (1f / movementSettings.frictionCoefY) * (Mathf.Pow(2.71828f, -movementSettings.frictionCoefY / rb.mass * Time.fixedDeltaTime)) *
            (movementSettings.frictionCoefY * transform.InverseTransformDirection(rb.velocity).y + rb.mass * accelerationY) - (rb.mass * accelerationY / movementSettings.frictionCoefY);
        float velocityZ = (1f / movementSettings.frictionCoefZ) * (Mathf.Pow(2.71828f, -movementSettings.frictionCoefZ / rb.mass * Time.fixedDeltaTime)) *
            (movementSettings.frictionCoefZ * transform.InverseTransformDirection(rb.velocity).z + rb.mass * accelerationZ) - (rb.mass * accelerationZ / movementSettings.frictionCoefZ);

        rb.velocity = transform.TransformDirection(new Vector3(velocityX, velocityY, velocityZ));

        ThusterAudio();
        if(accelerationZ > 0f && Vector3.Project(rb.velocity, transform.forward).z < 0f)
        {
            audioH.TriggerBrake();
        }

        // Release and Rollmode
        rollMode = InputHandler.rollModeInput;
    }

    private void ThusterAudio()
    {
        if(InputHandler.horThrusterInput < 0)
        {
            audioH.TriggerThruster(THRUSTERS.LEFT);
        }
        if(InputHandler.horThrusterInput > 0)
        {
            audioH.TriggerThruster(THRUSTERS.RIGHT);
        }
        if(InputHandler.verThrusterInput < 0)
        {
            audioH.TriggerThruster(THRUSTERS.DOWN);
        }
        if(InputHandler.verThrusterInput > 0)
        {
            audioH.TriggerThruster(THRUSTERS.UP);
        }
    }

    public void DetectState()
    {
        if (lastTrack != null)
        {
            lastTrack = currentTrack;
        }

        RaycastHit hit;

        Vector3 raycastOffset = (trackDetectState.transform.position - raycastOrigin.transform.position).normalized; // To raycast towards the trackdetector, to point forwards

        if (Physics.Raycast(raycastOrigin.transform.position, raycastOffset, out hit, Mathf.Infinity, trackMask))
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