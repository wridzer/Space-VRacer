using FMODUnity;
using System.Collections;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    private StudioEventEmitter[] emitters;

    private void Start()
    {
        emitters = GetComponentsInChildren<StudioEventEmitter>();
    }

    public void SoundOne()
    {
        emitters[0].Play();
    }

    public void SoundTwo()
    {
        emitters[1].Play();
    }

    public void SoundThree()
    {
        emitters[2].Play();
    }

}