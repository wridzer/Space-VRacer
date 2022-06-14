using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;


public class Start : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject playerPrefab, SpawnPoint;

    [SerializeField] private StudioEventEmitter redEmitter, greenEmitter;

    private void Awake()
    {
        gameManager.startObject = this;
        StartCountdown();
        greenEmitter.Play();
        gameManager.StartCountdown();
    }

    private IEnumerator StartCountdown()
    {
        redEmitter.Play();
        yield return new WaitForSeconds(1f);
        redEmitter.Play();
        yield return new WaitForSeconds(1f);
        redEmitter.Play();
        yield return new WaitForSeconds(1f);
    }

    public GameObject SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);

        // Maybe cameraselect and load settings here? you know for VR and non VR ect.

        return player;
    }
}