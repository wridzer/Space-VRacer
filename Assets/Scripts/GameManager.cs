using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int trackId, leaderboardSize = 4;
    [SerializeField] private GameObject leaderboard, nameSection, timeSection;
    [SerializeField] private float countdownTime = 3; // This is probaly just going to be 3 but didn't want to hardcode it
    // Probably a reference to the leaderboard

    private Stopwatch timer;
    private List<System.TimeSpan> times = new List<System.TimeSpan>();
    private Dictionary<int, Checkpoint> checkpoints = new Dictionary<int, Checkpoint>();
    private int currentCheckpoint = 0;

    private GameObject playerInstance;
    public Start startObject;

    private FMOD.Studio.EventInstance instance;

    private void SpawnTrack()
    {
        // This is for when trackbuilder gets implemented
    }
    private void Respawn()
    {
        playerInstance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerInstance.transform.position = checkpoints[currentCheckpoint].playerSpawn.transform.position;
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
        instance = GetComponent<StudioEventEmitter>().EventInstance;
        timer = new Stopwatch();
        playerInstance = startObject?.SpawnPlayer();

        StartRace();
    }

    private void StartRace()
    {
        playerInstance.GetComponent<Movement>().enabled = true;
        timer.Start();
    }

    // Finish and checkpoint can call this in awake to register them on this object. it will need a referance than tho
    // but when the builder is implemented it will have that because this will be constructing the track
    public void RegisterCheckpoint(Checkpoint _checkpoint)
    {
        // checkpoints.Add(_checkpoint); 
    }

    //Created this because there is no trackbuilder yet and otherwise they get registered in the wrong order
    public void RegisterCheckpoint(Checkpoint _checkpoint, int _checkpointNumber)
    {
        checkpoints.Add(_checkpointNumber, _checkpoint);
    }

    public void OnCheckpoint(Checkpoint _checkpoint)
    {
        timer.Stop();
        System.TimeSpan currentTime = timer.Elapsed;
        timer.Start();
        if(checkpoints[currentCheckpoint] == _checkpoint)
        {
            currentCheckpoint++;
            times.Add(currentTime);
            // Network currenttime
            // Display currenttime
            UnityEngine.Debug.Log(currentTime);
        } else
        {
            // Wrong checkpoint
        }
        if(currentCheckpoint == checkpoints.Count)
        {
            Finish(currentTime);
        }
    }

    private async void Finish(System.TimeSpan _endTime)
    {
        await DatabaseManager.UploadScore(trackId, _endTime);
        GetLeaderboard();
        leaderboard.SetActive(true);
        UnityEngine.Debug.Log("Finished");
        instance.start();
    }

    private async void GetLeaderboard()
    {
        string nameString = "", timeString = "";
        int timesToShow = leaderboardSize;

        var leaderboardTimes = await DatabaseManager.GetGlobalLeaderboard(trackId);
        if (leaderboardTimes.times.Length < leaderboardSize) 
            timesToShow = leaderboardTimes.times.Length;

        for (int i = 0; i < timesToShow; i++)
        {
            nameString += leaderboardTimes.times[i].name + System.Environment.NewLine;
            timeString += System.TimeSpan.FromMilliseconds(leaderboardTimes.times[i].time) + System.Environment.NewLine;
        }

        nameSection.GetComponent<TMP_Text>().text = nameString;
        timeSection.GetComponent<TMP_Text>().text = timeString;
    }
}
