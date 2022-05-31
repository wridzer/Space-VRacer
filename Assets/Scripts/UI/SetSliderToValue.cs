using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SliderValue { AudioVolume }

public class SetSliderToValue : MonoBehaviour
{
    public SliderValue sliderValue;

    private void OnEnable()
    {
        Slider slider = GetComponent<Slider>();
        switch(sliderValue)
        {
            case SliderValue.AudioVolume: slider.value = PlayerInputSettings.AudioVolume; break;
            default: Debug.LogError("Yo pannenkoek, je bent vergeten de enum ook in de switch te zetten. Pannenkoek."); break;
        }
    }
}
