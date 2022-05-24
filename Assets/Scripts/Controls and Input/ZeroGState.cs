using System.Collections;
using UnityEngine;


public class ZeroGState : FlightState
{
    public ZeroGState(MovementSettingObject _Settings, Movement _Movement, LayerMask _LayerMask) : base(_Settings, _Movement, _LayerMask)
    {
        Settings = _Settings;
        Movement = _Movement;
    }

    public override void OnExit()
    {
        Movement.Move();
    }

    public override void OnUpdate()
    {
        Movement.Move();
        Movement.Rotate();
        Movement.DetectState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
}