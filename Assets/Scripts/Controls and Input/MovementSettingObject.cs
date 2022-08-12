using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flight/MovementSettingObject")]
public class MovementSettingObject : ScriptableObject
{
    [Header("Ship Settings")]
    public float acceleration;
    public float topSpeed, verticalThrusterAcceleration, horizontalThrusterAcceleration, reverseTopSpeed, pitchSpeed, rollSpeed, yawSpeed, totalRotationSpeed, frictionCoefX, frictionCoefY, frictionCoefZ;

    [Header("Maglev Settings")]
    public float decoupleSpeed;
    public float maglevRotStrengthSnap, maglevRotStrengthRot, maglevDisStrength, maglevDistance, maglevDistanceMultiplier, maglevSnapAngle;

    [Header("Layer and State")]
    public FlightStates flightStates;
    public LayerMask layerMask;
}

public enum FlightStates
{
    Maglev = 0,
    ZeroG = 1
}