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
    public float maglevRotStrengthMax, maglevRotStrengthMin, maglevDisStrength, maglevDistance, maglevDistanceMultiplier, maglevSnapAngle;
    public AnimationCurve maglevRotStrength;

    [Header("Layer and State")]
    public FlightStates flightStates;
    public LayerMask layerMask;
}

public enum FlightStates
{
    Maglev = 0,
    ZeroG = 1
}