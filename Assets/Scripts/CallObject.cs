using System.Collections;
using UnityEngine;


[CreateAssetMenu(menuName = "Call")]
public class CallObject : ScriptableObject
{
    public bool IsCriminal;
    public AudioClip callSound;
    public float waitToRing;
    public string callName;
    public GameObject headlinePrefab;
}