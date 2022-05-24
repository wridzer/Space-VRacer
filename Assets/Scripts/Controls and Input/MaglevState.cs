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
    }

    public override void OnUpdate()
    {
        Movement.Move();
        Movement.KeepAlligned();
        Movement.Rotate();
        Movement.DetectState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
}