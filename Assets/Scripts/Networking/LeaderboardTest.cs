using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


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

    private Task ServerLogIn()
    {
        sessId = DatabaseManager.ServerLogin(serverId, serverPass).Result;
        if (sessId == null)
        {
            Debug.Log("Server login failed: session ID=" + sessId);
        }
        else
        {
            Debug.Log("Server login succes: session ID=" + sessId);
        }
        return Task.CompletedTask;
    }


    private async Task PlayerLogIn()
    {
        await ServerLogIn();
        await DatabaseManager.PlayerLogin(sessId, playerEmail, playerPass);

        Debug.Log("Logged in");
    }

    public async void Login()
    {
        Debug.Log("Trying to login");
        await PlayerLogIn();
    }

    public async void AddTime()
    {
        Debug.Log("Trying to upload time");
        await DatabaseManager.UploadScore(sessId, trackId, insertTime);
    }

    public void FetchLeaderboards()
    {
        Debug.Log("Trying to fetch leaderboards");

        List<System.TimeSpan> leaderboard = new List<System.TimeSpan>();

        leaderboard= DatabaseManager.GetGlobalLeaderboard(sessId, trackId);

        foreach(var time in leaderboard)
        {
            Debug.Log(time);
        }

        leaderboard= DatabaseManager.GetPlayerLeaderboard(sessId, trackId);

        foreach(var time in leaderboard)
        {
            Debug.Log(time);
        }

    }

}