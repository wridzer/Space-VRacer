using System.Collections;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointNumber;
    [SerializeField] private GameManager gameManager;

    public GameObject playerSpawn;

    private void Awake()
    {
        gameManager.RegisterCheckpoint(this, checkpointNumber); // when trackbuilder implemented, this should change
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.OnCheckpoint(this);
    }
}