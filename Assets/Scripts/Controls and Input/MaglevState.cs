using System.Collections;
using UnityEngine;

public class MaglevState : FlightState
{
    public MaglevState(MovementSettingObject _Settings, Movement _Movement, LayerMask _LayerMask) : base(_Settings, _Movement, _LayerMask)
    {
        Settings = _Settings;
        Movement = _Movement;
    }

    public override void OnExit()
    {
        Movement.Decouple();
        Movement.Move();
        Movement.Rotate();
        Movement.audioH.TriggerMaglevExit();
        Movement.audioH.InMaglev = false;
    }

    public override void OnUpdate()
    {
        Movement.Move();
        Movement.KeepAlligned();
        Movement.localYRot = 0;
        Movement.deltaMagRot.y = 0;
        Movement.Rotate();
        Movement.DetectState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Movement.localYRot = Movement.rb.transform.localEulerAngles.y;
        Movement.audioH.TriggerMaglevEnter();
        Movement.audioH.InMaglev = true;
    }
}