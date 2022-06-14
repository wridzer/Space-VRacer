using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardTest : MonoBehaviour
{
    [SerializeField] private string serverPass = "admin", playerEmail = "wridzer12@gmail.com", playerPass = "Wachtwoord123";
    [SerializeField] private int serverId = 1, trackId = 1, insertTimeInMillis = 70000;


    private System.TimeSpan insertTime;

    private string sessId;

    private void Start()
    {
        insertTime = System.TimeSpan.FromMilliseconds(insertTimeInMillis);
    }

    private async Task ServerLogIn()
    {
        sessId = await DatabaseManager.ServerLogin(serverId, serverPass);
        if (sessId == null)
        {
            Debug.Log("Server login failed: session ID=" + sessId);
        }
        else
        {
            Debug.Log("Server login succes: session ID=" + sessId);
        }
    }


    private async Task PlayerLogIn()
    {
        await ServerLogIn();
        await DatabaseManager.PlayerLogin(playerEmail, playerPass);

        Debug.Log("Logged in");
    }

    public void Login()
    {
        PlayerLogIn();
    }

    public async void AddTime()
    {
        Debug.Log("Trying to upload time");
        await DatabaseManager.UploadScore(trackId, insertTime);
    }

    public async void FetchLeaderboards()
    {
        Debug.Log("Trying to fetch leaderboards");

        Leaderboard leaderboard;

        leaderboard = await DatabaseManager.GetGlobalLeaderboard(trackId);

        foreach (LeaderboardObject time in leaderboard.times)
        {
            System.TimeSpan displayTime = System.TimeSpan.FromMilliseconds(time.time);
            Debug.Log(displayTime + " " + time.name);
        }

        leaderboard = await DatabaseManager.GetPlayerLeaderboard(trackId);

        foreach (LeaderboardObject time in leaderboard.times)
        {
            Debug.Log(time.time);
        }

    }

}