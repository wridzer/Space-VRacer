using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flight/MovementSettingObject")]
public class MovementSettingObject : ScriptableObject
{
    [Header("Ship Settings")]
    public float acceleration;
    public float topSpeed, thrusterAcceleration, reverseTopSpeed, pitchSpeed, rollSpeed, yawSpeed, totalRotationSpeed;

    [Header("Maglev Settings")]
    public float decoupleSpeed;
    public float maglevRotStrength, maglevDisStrength, maglevDistance, maglevDistanceMultiplier;

    [Header("Layer and State")]
    public FlightStates flightStates;
    public LayerMask layerMask;
}

public enum FlightStates
{
    Maglev = 0,
    ZeroG = 1
}