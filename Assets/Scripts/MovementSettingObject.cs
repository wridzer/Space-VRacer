using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flight/MovementSettingObject")]
public class MovementSettingObject : ScriptableObject
{
    // Movement variables
    public float acceleration, topSpeed, thrusterAcceleration, reverseTopSpeed, pitchSpeed, rollSpeed, yawSpeed, decoupleSpeed, maglevStrength, totalRotationSpeed;
    public FlightStates flightStates;
    public LayerMask layerMask;
}

public enum FlightStates
{
    Maglev = 0,
    ZeroG = 1
}