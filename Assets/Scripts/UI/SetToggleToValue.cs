using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ToggleValue { RollmodeToggle, RollmodeInverted, ToggleReleaseOnExit, InvertYAxis, InvertXAxis }

public class SetToggleToValue : MonoBehaviour
{
    public ToggleValue toggleValue;

    private void OnEnable()
    {
        Toggle toggle = GetComponent<Toggle>();
        switch(toggleValue)
        {
            case ToggleValue.RollmodeToggle: toggle.isOn = PlayerInputSettings.RollmodeToggle; break;
            case ToggleValue.RollmodeInverted: toggle.isOn = PlayerInputSettings.RollmodeInverted; break;
            case ToggleValue.ToggleReleaseOnExit: toggle.isOn = PlayerInputSettings.ToggleReleaseOnExit; break;
            case ToggleValue.InvertXAxis: toggle.isOn = PlayerInputSettings.InvertXAxis; break;
            case ToggleValue.InvertYAxis: toggle.isOn = PlayerInputSettings.InvertYAxis; break;
            default: Debug.LogError("Yo pannenkoek, je bent vergeten de enum ook in de switch te zetten. Pannenkoek."); break;
        }
    }
}
