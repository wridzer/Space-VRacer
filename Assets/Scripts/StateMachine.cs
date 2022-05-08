using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private FlightState currentState;
    private Dictionary<int, FlightState> allStates = new Dictionary<int, FlightState>();

    public void AddState(FlightState _State)
    {
        allStates.Add(_State.LayerMask, _State);
    }

    public void Update()
    {
        currentState?.OnUpdate();
        Debug.Log(currentState?.ToString());
    }

    public void SwitchState(int _Layer)
    {
        currentState?.OnExit();
        if (allStates.ContainsKey(_Layer))
        {
            currentState = allStates[_Layer];
        }
        currentState?.OnEnter();
    }

    public void ClearStates()
    {
        allStates.Clear();
    }
}