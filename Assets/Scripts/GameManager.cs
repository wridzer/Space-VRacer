using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float countdownTime = 3; // This is probaly just going to be 3 but didn't want to hardcode it

    private Stopwatch timer;
    private List<System.TimeSpan> times = new List<System.TimeSpan>();
    private List<Checkpoint> checkpoints = new List<Checkpoint>();
    private int currentCheckpoint = 0;

    private GameObject playerInstance;
    public Start startObject;

    private void SpawnTrack()
    {
        // This is for when trackbuilder gets implemented
    }

    private void Awake()
    {
        timer = new Stopwatch();
    }

    private void Respawn()
    {
        playerInstance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerInstance.transform.position = checkpoints[currentCheckpoint].playerSpawn;
    }

    private void StartOver()
    {
        // Delete player
        Destroy(playerInstance);

        // Clear Times
        times.Clear();
        timer.Reset();
        currentCheckpoint = 0;

        StartCountdown();
    }

    public void StartCountdown()
    {
        playerInstance = startObject?.SpawnPlayer();

        // show countdown
    }

    private void StartRace()
    {
        timer.Start();
    }

    // Finish and checkpoint can call this in awake to register them on this object. it will need a referance than tho
    // but when the builder is implemented it will have that because this will be constructing the track
    public void RegisterCheckpoint(Checkpoint _checkpoint)
    {
        checkpoints.Add(_checkpoint);
    }

    //Created this because there is no trackbuilder yet and otherwise the get registered in the wrong order
    public void RegisterCheckpoint(Checkpoint _checkpoint, int _checkpointNumber)
    {
        checkpoints[_checkpointNumber] = _checkpoint;
    }

    public void OnCheckpoint(Checkpoint _checkpoint)
    {
        System.TimeSpan currentTime = timer.Elapsed;
        if(checkpoints[currentCheckpoint] == _checkpoint)
        {
            currentCheckpoint++;
            times.Add(currentTime);
            // Network currenttime
            // Display currenttime
        } else
        {
            // Wrong checkpoint
        }
        if(currentCheckpoint == checkpoints.Count)
        {
            Finish(currentTime);
        }
    }

    private void Finish(System.TimeSpan _endTime)
    {
        // Do finish stuff
    }
}
