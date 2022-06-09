using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Net.Http;


public static class DatabaseManager
{
    private static async Task<string> WebRequest(string _url)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(_url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

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

    public static async Task<string> PlayerLogin(string _sessId, string _email, string _password)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/user_login.php?PHPSESSID={_sessId}&email={_email}&password={_password}";

        string isSucces = await WebRequest(URL);
        return isSucces.ToString();
    }
    public static async Task<string> ServerLogin(int _serverId, string _serverPass)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/server_login.php?id={_serverId}&password={_serverPass}";
        Debug.Log(URL);
        string isSucces = await WebRequest(URL);
        return isSucces;
    }

    public static async Task UploadScore(string _sessId, int _trackId, System.TimeSpan _time)
    {
        int timeAsInt = (int)_time.TotalMilliseconds;
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/insert_time.php?PHPSESSID={_sessId}&time={timeAsInt}&track_id={_trackId}";

        await WebRequest(URL);

        Debug.Log("Uploaded to: " + URL);
    }

    public static async Task<Leaderboard> GetPlayerLeaderboard(string _sessId, int _trackId)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/get_player_leaderboard.php?PHPSESSID={_sessId}&track_id={_trackId}";

        string response = await WebRequest(URL);
        Debug.Log(URL);
        Debug.Log(response);

        Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(response);
        return leaderboard;
    }
    public static async Task<Leaderboard> GetGlobalLeaderboard(string _sessId, int _trackId)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/get_global_leaderboard.php?PHPSESSID={_sessId}&track_id={_trackId}";

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