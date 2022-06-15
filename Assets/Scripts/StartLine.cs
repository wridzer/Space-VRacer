using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;


public class StartLine : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject playerPrefab, SpawnPoint;

    [SerializeField] private StudioEventEmitter redEmitter, greenEmitter;

    [HideInInspector] public GameObject playerInstance;

    private void Start()
    {
        gameManager.startObject = this; // idk why but removing this breaks things
        playerInstance = SpawnPlayer();
        StartCoroutine(StartCountdown(3));
    }

    private IEnumerator StartCountdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            yield return new WaitForSeconds(1f);
            count--;
            redEmitter.Play();
        }
        greenEmitter.Play();
        gameManager.StartCountdown();
    }

    public GameObject SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);

        // Maybe cameraselect and load settings here? you know for VR and non VR ect.

        return player;
    }
}