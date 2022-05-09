using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode { Solo, Hotseat, HotseatAdditive}
public class GameplaySettings : MonoBehaviour
{
    public static GameplaySettings Instance { get; private set; } //Sorry Wridzer

    public GameMode selectedGameMode;
    public GameObject selectedLevel;

    private void Awake()
    {
        if(Instance != null) { Debug.LogWarning("A gameplay settings object already existed. Destroyed this."); Destroy(gameObject); return; }
        DontDestroyOnLoad(this);
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
