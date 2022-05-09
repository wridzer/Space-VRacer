using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode { Solo, Hotseat, HotseatAdditive}


//Ja nee dit is probably lelijk as fuck
[CreateAssetMenu(fileName = "GameplaySettings", menuName = "ScriptableObjects/GameplaySettings")]
public class GameplaySettings : ScriptableObject
{
    public static GameMode selectedGameMode;
    public static GameObject selectedLevel;

    //Functions to set stuff via buttons.

    public void SetGameMode(int _gameMode)
    {
        SetGameMode((GameMode)_gameMode);
    }

    public void SetGameMode(GameMode _gameMode)
    {
        selectedGameMode = _gameMode;
    }

    public void SetLevel(GameObject _level)
    {
        selectedLevel = _level;
    }
}
