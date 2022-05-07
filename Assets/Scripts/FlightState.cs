﻿using System.Collections;
using UnityEngine;

public abstract class FlightState
{
    public MovementSettingObject Settings { get; set; }
    public LayerMask LayerMask { get; set; }
    public Movement Movement { get; set; }

    public FlightState( MovementSettingObject _Settings, Movement _Movement, LayerMask _LayerMask)
    {
        Settings = _Settings;
        Movement = _Movement;
        LayerMask = _LayerMask;
    }

    public virtual void OnEnter()
    {
        Movement.movementSettings = Settings;
    }
    public abstract void OnUpdate();
    public abstract void OnExit();
}