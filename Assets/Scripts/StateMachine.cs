using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private FlightState currentState;
    private Dictionary<LayerMask, FlightState> allStates = new Dictionary<LayerMask, FlightState>();

    public void AddState(FlightState _State)
    {
        allStates.Add(_State.LayerMask, _State);
    }

    public void Update()
    {
        currentState?.OnUpdate();
    }

    public void SwitchState(LayerMask _LayerMask)
    {
        currentState?.OnExit();
        if (allStates.ContainsKey(_LayerMask))
        {
            currentState = allStates[_LayerMask];
        }
        currentState?.OnEnter();
    }

    public void ClearStates()
    {
        allStates.Clear();
    }
}