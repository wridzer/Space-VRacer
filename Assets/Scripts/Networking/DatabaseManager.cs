using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Net.Http;


public static class DatabaseManager
{
    private static string sessId = "", serverPass = "admin", playerEmail = "", playerPass = "";
    private static int serverId = 1;

    private static async Task<string> WebRequest(string _url)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(_url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // TODO: if session is over than login server and user and try again

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Debug.LogError("\nException Caught!");
                Debug.LogError("Message :" + e.Message);
            }

            return null;
        }
    }

    public static async Task<string> GetPlayerName()
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/fetch_username.php?PHPSESSID={sessId}";

        string response = await WebRequest(URL);
        return response;
    }

    public static async Task<string> PlayerLogin(string _email, string _password)
    {
        playerEmail = _email;
        playerPass = _password;

        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/user_login.php?PHPSESSID={sessId}&email={_email}&password={_password}";

        string isSucces = await WebRequest(URL);
        return isSucces.ToString();
    }
    public static async Task<string> PlayerLogin()
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/user_login.php?PHPSESSID={sessId}&email={playerEmail}&password={playerPass}";

        string isSucces = await WebRequest(URL);
        return isSucces.ToString();
    }
    public static async Task<string> ServerLogin(int _serverId, string _serverPass)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/server_login.php?id={_serverId}&password={_serverPass}";
        Debug.Log(URL);
        sessId = await WebRequest(URL);
        return sessId;
    }

    public static async Task UploadScore(int _trackId, System.TimeSpan _time)
    {
        int timeAsInt = (int)_time.TotalMilliseconds;
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/insert_time.php?PHPSESSID={sessId}&time={timeAsInt}&track_id={_trackId}";

        await WebRequest(URL);

        Debug.Log("Uploaded to: " + URL);
    }

    public static async Task<Leaderboard> GetPlayerLeaderboard(int _trackId)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/get_player_leaderboard.php?PHPSESSID={sessId}&track_id={_trackId}";

        string response = await WebRequest(URL);
        Debug.Log(URL);
        Debug.Log(response);

        Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(response);
        return leaderboard;
    }
    public static async Task<Leaderboard> GetGlobalLeaderboard(int _trackId)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/get_global_leaderboard.php?PHPSESSID={sessId}&track_id={_trackId}";

        string response = await WebRequest(URL);
        Debug.Log(URL);
        Debug.Log(response);

        Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(response);
        return leaderboard;
    }
}

public class LeaderboardObject
{
    public int time { get; set; }
    public string name { get; set; }
}

public class Leaderboard
{
    public LeaderboardObject[] times { get; set; }
}