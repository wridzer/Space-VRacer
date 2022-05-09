using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Yes, this is fucking weird
public class ManagerLoader : MonoBehaviour
{
    private void Start()
    {
        switch(GameplaySettings.Instance.selectedGameMode)
        {
            case GameMode.Solo: break;
            case GameMode.Hotseat: break;
            case GameMode.HotseatAdditive: break;
        }
    }
}
