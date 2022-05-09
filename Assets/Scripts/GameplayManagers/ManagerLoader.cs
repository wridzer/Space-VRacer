using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Yes, this is fucking weird
public class ManagerLoader : MonoBehaviour
{
    [SerializeField] bool debugMode = false;
    [SerializeField] GameplayManager debugManager;
    [SerializeField] GameObject debugLevel;

    [SerializeField] GameplayManager[] managers; //soloManager, hotseatManager, hotseatAdditiveManager; //Ja maar nee

    [SerializeField] Camera debugCamera; //HHAHAHAHHAHAA NEE

    public void StartGame()
    {
        if(debugMode)
        {
            GameplayManager debMan = Instantiate(debugManager);
            debMan.InstantiateLevel(debugLevel);           
            
            return;
        }

        GameplayManager manager = Instantiate(managers[(int)GameplaySettings.selectedGameMode].gameObject).GetComponent<GameplayManager>();
        debugCamera.enabled = false; //turn off camera that's only there for UI shit.

        manager.InstantiateLevel(GameplaySettings.selectedLevel);
    }
}
