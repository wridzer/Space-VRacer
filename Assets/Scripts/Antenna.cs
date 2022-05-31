using System.Collections;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    [SerializeField] private GameObject[] signalPoints;
    private GameObject bestSignal;
    private bool badSignal = false;
    private AudioSource audioSource;
    [SerializeField] private AudioClip distortion;
    private float timer = 20;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bestSignal = signalPoints[Random.Range(0, signalPoints.Length - 1)];
    }

    public void NewSignal()
    {
        bestSignal = signalPoints[Random.Range(0, signalPoints.Length - 1)];
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) badSignal = true;
        if (badSignal)
        {
            DistortAudio();
        }
    }

    public void GotAntenna(GameObject orb)
    {
        if (orb == bestSignal)
        {
            badSignal = false;
            timer = 1;
        }
    }

    private void DistortAudio()
    {
        //audioSource.PlayOneShot(distortion);
    }
}