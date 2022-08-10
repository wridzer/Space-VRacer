using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class NetworkLogin : MonoBehaviour
{
    [SerializeField] private string serverPass = "admin", playerEmail = "wridzer12@gmail.com", playerPass = "Wachtwoord123";
    [SerializeField] private int serverId = 1, trackId = 1;

    private string sessId;

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
    void Awake()
    {
        PlayerLogIn();
    }
}