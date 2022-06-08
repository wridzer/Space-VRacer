using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public static class DatabaseManager
{
    private static async Task<UnityWebRequest.Result> WebRequest(string _url)
    {
        UnityWebRequest request = new UnityWebRequest();
        request.url = _url;
        request.SendWebRequest();

        while (!request.isDone)
        {
            // WAAROM KAN IK NIET AWAITEN?!?!?!
        }

        return request.result;
    }

    public static async Task<string> PlayerLogin(string _sessId, string _email, string _password)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/user_login.php?PHPSESSID={_sessId}&email={_email}&password={_password}";

        UnityWebRequest.Result isSucces = await WebRequest(URL);
        return isSucces.ToString();
    }
    public static async Task<string> ServerLogin(int _serverId, string _serverPass)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/server_login.php?id={_serverId}&password={_serverPass}";
        Debug.Log(URL);
        UnityWebRequest.Result isSucces = await WebRequest(URL);
        return isSucces.ToString();
    }

    public static async Task UploadScore(string _sessId, int _trackId, System.TimeSpan _time)
    {
        uint timeAsInt = (uint)_time.Milliseconds;
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/insert_time.php?PHPSESSID={_sessId}&time={timeAsInt}&track_id={_trackId}";

        await WebRequest(URL);

        Debug.Log("Uploaded to: " + URL);
    }

    public static List<System.TimeSpan> GetPlayerLeaderboard(string _sessId, int _trackId)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/get_player_leaderboard.php?PHPSESSID={_sessId}&track_id={_trackId}";

        UnityWebRequest www = new UnityWebRequest(URL);

        if (string.IsNullOrEmpty(www.error))
        {
            // parse www.text as json
            List<System.TimeSpan> leaderboard = JsonConvert.DeserializeObject<List<System.TimeSpan>>(www.result.ToString());
            return leaderboard;
        }
        else
        {
            Debug.LogError(www.error);
            return new List<System.TimeSpan>();
        }
    }
    public static List<System.TimeSpan> GetGlobalLeaderboard(string _sessId, int _trackId)
    {
        string URL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/get_global_leaderboard.php?PHPSESSID={_sessId}&track_id={_trackId}";

        UnityWebRequest www = new UnityWebRequest(URL);

        if (string.IsNullOrEmpty(www.error))
        {
            // parse www.text as json
            List<System.TimeSpan> leaderboard = JsonConvert.DeserializeObject<List<System.TimeSpan>>(www.result.ToString());
            return leaderboard;
        }
        else
        {
            Debug.LogError(www.error);
            return new List<System.TimeSpan>();
        }
    }
}