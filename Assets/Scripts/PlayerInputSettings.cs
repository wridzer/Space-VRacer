using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Weird combination of a scriptable object and a static class to make player input settings available project wide but also assignable in 
/// UI Events. Pog?
/// Should probably use JSON instead of playerprefs but shrug.
/// </summary>
[CreateAssetMenu(fileName = "PlayerInputSettings", menuName = "ScriptableObjects/PlayerInputSettings")]
public class PlayerInputSettings : ScriptableObject
{
    public bool saveSettingsOnEdit = true;
    public static bool RollmodeToggle, RollmodeInverted;
    public static float AudioVolume;
    public static bool ToggleReleaseOnExit;
    public static bool InvertYAxis, InvertXAxis; //Option for inverting the x-axis in case people want to get freaky with it
    public static bool QuadraticRollInput;

    #region set functions for UI events
    public void SetRollmodeToggle(bool value)
    {
        RollmodeToggle = value;
        if (saveSettingsOnEdit) { SaveSettings(); }
    }

    public void SetRollmodeInverted(bool value)
    {
        RollmodeInverted = value;
        if (saveSettingsOnEdit) { SaveSettings(); }
    }

    public void SetAudioVolume(float value)
    {
        AudioVolume = value;
        AudioListener.volume = AudioVolume;
        if (saveSettingsOnEdit) { SaveSettings(); }
    }

    public void SetToggleReleaseOnExit(bool value)
    {
        ToggleReleaseOnExit = value;
        if (saveSettingsOnEdit) { SaveSettings(); }
    }

    public void SetInvertYAxis(bool value)
    {
        InvertYAxis = value;
        if (saveSettingsOnEdit) { SaveSettings(); }
    }

    public void SetInvertXAxis(bool value)
    {
        InvertXAxis = value;
        if (saveSettingsOnEdit) { SaveSettings(); }
    }

    public void SetQuadraticRollInput(bool value)
    {
        QuadraticRollInput = value;
        if (saveSettingsOnEdit) { SaveSettings(); }
    }
    #endregion

    #region saving/loading

    public void Save()
    {
        SaveSettings();
    }

    public void Load()
    {
        LoadSettings();
    }

    public static void SaveSettings()
    {
        PlayerPrefs.SetInt("RollmodeToggle", Utility.BoolToInt(RollmodeToggle));
        PlayerPrefs.SetInt("RollmodeInverted", Utility.BoolToInt(RollmodeInverted));
        PlayerPrefs.SetFloat("AudioVolume", AudioVolume);
        PlayerPrefs.SetInt("ToggleRelease", Utility.BoolToInt(ToggleReleaseOnExit));
        PlayerPrefs.SetInt("InvertY", Utility.BoolToInt(InvertYAxis));
        PlayerPrefs.SetInt("InvertX", Utility.BoolToInt(InvertXAxis));
        PlayerPrefs.SetInt("QuadraticRoll", Utility.BoolToInt(QuadraticRollInput));
        PlayerPrefs.Save();
    }

    public static void LoadSettings()
    {
        RollmodeToggle = Utility.IntToBool(PlayerPrefs.GetInt("RollmodeToggle", 0));
        RollmodeInverted = Utility.IntToBool(PlayerPrefs.GetInt("RollmodeInverted", 0));
        AudioVolume = PlayerPrefs.GetFloat("AudioVolume", 0.5f);
        ToggleReleaseOnExit = Utility.IntToBool(PlayerPrefs.GetInt("ToggleRelease", 1));
        InvertYAxis = Utility.IntToBool(PlayerPrefs.GetInt("InvertY", 0));
        InvertXAxis = Utility.IntToBool(PlayerPrefs.GetInt("InvertX", 0));
        QuadraticRollInput = Utility.IntToBool(PlayerPrefs.GetInt("QuadraticRoll", 1));
    }

    #endregion
}
