using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckpointMana : MonoBehaviour
{
    public Transform playerRespawnPoint; //if we do respawning

    //Note: This assumes that Checkpoints are instantiated AFTER the GameplayManager has been instantiated. Using Start breaks things.
    //Might have to be changed based on how we do things
    private void Awake()
    {
        GameplayManager.Instance.AddCheckpoint(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Mijs: dit word aangeroepen als de player de checkpoint doorgaat
        //Just going to assume real quick that only the player can trigger things
        GameplayManager.Instance.PassCheckpoint(this);
    }
}
