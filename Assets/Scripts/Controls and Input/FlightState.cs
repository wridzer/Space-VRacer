using System.Collections;
using UnityEngine;

public abstract class FlightState
{
    public MovementSettingObject Settings { get; set; }
    public int Layer { get; set; }
    public Movement Movement { get; set; }

    public FlightState( MovementSettingObject _Settings, Movement _Movement, LayerMask _Layer)
    {
        Settings = _Settings;
        Movement = _Movement;
        Layer = _Layer;
    }

    public virtual void OnEnter()
    {
        Movement.movementSettings = Settings;
    }
    public abstract void OnUpdate();
    public abstract void OnExit();
}