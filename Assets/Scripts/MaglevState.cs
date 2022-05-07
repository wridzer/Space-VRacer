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
        // Decouple with a little bit of yeet
        // throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        // Kinda force ship straight
        // throw new System.NotImplementedException();
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
}