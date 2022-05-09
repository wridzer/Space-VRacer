using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode { Solo, Hotseat, HotseatAdditive}

//Yay statics
public static class GameplaySettings
{
    public static GameMode selectedGameMode;
    public static GameObject selectedLevel;

    public static void SetGameMode(GameMode _gameMode)
    {
        selectedGameMode = _gameMode;
    }

    public static void SetLevel(GameObject _level)
    {
        selectedLevel = _level;
    }
}
