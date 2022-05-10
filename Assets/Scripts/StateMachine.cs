using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private FlightState currentState;
    private Dictionary<int, FlightState> allStates = new Dictionary<int, FlightState>();

    public void AddState(FlightState _State)
    {
        Debug.Log(_State.Layer);
        allStates.Add(_State.Layer, _State);
    }

    public void Update()
    {
        currentState?.OnUpdate();
    }

    public void SwitchState(int _Layer)
    {
        if (allStates[_Layer] != currentState)
        {
            currentState?.OnExit();
            if (allStates.ContainsKey(_Layer))
            {
                currentState = allStates[_Layer];
            }
            currentState?.OnEnter();
        }

    }

    public void ClearStates()
    {
        allStates.Clear();
    }
}