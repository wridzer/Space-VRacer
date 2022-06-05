using System.Collections;
using UnityEngine;


public class Start : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject playerPrefab, SpawnPoint;

    private void Awake()
    {
        gameManager.startObject = this;
        gameManager.StartCountdown();
    }

    public GameObject SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);

        // Maybe cameraselect and load settings here? you know for VR and non VR ect.

        return player;
    }
}