using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointNumber;
    [SerializeField] private GameManager gameManager;

    public GameObject playerSpawn;

    private EventInstance instance;

    private void Awake()
    {
        instance = GetComponent<StudioEventEmitter>().EventInstance;
        gameManager.RegisterCheckpoint(this, checkpointNumber); // when trackbuilder implemented, this should change
    }

    private void OnTriggerEnter(Collider other)
    {
        instance.start();
        gameManager.OnCheckpoint(this);
    }
}