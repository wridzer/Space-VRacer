using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Flight/MovementSettingObject")]
public class MovementSettingObject : ScriptableObject
{
    // Movement variables
    public float acceleration, topSpeed, deccelaration, brakes, thrusterAcceleration, reverseTopSpeed, pitchSpeed, rollSpeed, yawSpeed;
    public FlightState flightState;
    public LayerMask layerMask;

}