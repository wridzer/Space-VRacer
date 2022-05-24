using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    private CallObject currentCall;
    [SerializeField] private ListnerPhone phone;
    [SerializeField] private AudioClip reportSound;
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Report()
    {
        currentCall = phone.GetComponent<ListnerPhone>().currentCall;

        if(currentCall != null)
        {
            ScoreKeeper.AddScore(currentCall);
        }
        //animator.SetBool("Pressed", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Pressed", true);
        audioSource.PlayOneShot(reportSound);
        Report();
        Debug.Log("Reported caller");
    }
}