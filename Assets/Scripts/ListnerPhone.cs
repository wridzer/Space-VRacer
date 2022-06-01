using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListnerPhone : MonoBehaviour
{
    [HideInInspector] public CallObject currentCall;
    private AudioSource audioSource;
    private PhoneManager phoneManager;
    [SerializeField] private GameObject phoneHolder;

    [SerializeField] private float volume;

    [SerializeField] private AudioClip deadLine;
    [SerializeField] private float maxDistance;
    [SerializeField] private Vector3 startPos;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        phoneManager = GetComponent<PhoneManager>();
    }

    private void Start()
    {
        audioSource.volume = 0;
    }

    private void Update()
    {
        if (!audioSource.isPlaying && currentCall != null)
        {
            phoneManager.HungUp();
            currentCall = null;
        }
        if (Vector3.Distance(transform.position, phoneHolder.transform.position) > maxDistance)
        {
            transform.position = startPos;
        }
    }

    //get call
    public void GetCall(CallObject call)
    {
        StartCoroutine(waitForRing(call));
    }

    //ring
    public void Ring(CallObject call)
    {
        currentCall = call;
        phoneHolder.GetComponent<PhoneHolder>().Ring();
        audioSource.PlayOneShot(currentCall.callSound);
    }

    //pick up
    public void PickUp()
    {
        if (currentCall != null)
        {
            audioSource.volume = volume;
        }
        else
        {
            audioSource.PlayOneShot(deadLine);
        }
    }

    //hang up
    public void HangUp()
    {
        audioSource.volume = 0;
    }

    private IEnumerator waitForRing(CallObject call)
    {
        yield return new WaitForSeconds(call.waitToRing);
        Ring(call);
    }
}
