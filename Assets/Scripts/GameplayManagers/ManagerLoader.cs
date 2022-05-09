using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Yes, this is fucking weird
public class ManagerLoader : MonoBehaviour
{
    [SerializeField] bool debugMode = false;
    [SerializeField] GameplayManager debugManager;
    [SerializeField] GameObject debugLevel;

    private void Start()
    {
        if(debugMode)
        {
            GameplayManager manager = Instantiate(debugManager);
            manager.InstantiateLevel(debugLevel);
            
            
            return;
        }

        switch(GameplaySettings.Instance.selectedGameMode)
        {
            case GameMode.Solo: break;
            case GameMode.Hotseat: break;
            case GameMode.HotseatAdditive: break;
        }
    }
}
