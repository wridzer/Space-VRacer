using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloModeManager : GameplayManager
{
    private void Start()
    {
        //DEBUG
        SpawnPlayer();
        StartCoroutine(StartRun());
    }

    protected override void PlayerFinished()
    {
        //show finish menu
        //save time
        timerActive = false;
        Debug.Log(timer);
    }
}
