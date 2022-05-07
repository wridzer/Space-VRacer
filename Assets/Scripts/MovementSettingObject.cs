using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flight/MovementSettingObject")]
public class MovementSettingObject : ScriptableObject
{
    // Movement variables
    public float acceleration, topSpeed, deccelaration, brakes, thrusterAcceleration, reverseTopSpeed, pitchSpeed, rollSpeed, yawSpeed;
    public FlightStates flightStates;
    public LayerMask layerMask;
}

public enum FlightStates
{
    Maglev = 0,
    ZeroG = 1
}