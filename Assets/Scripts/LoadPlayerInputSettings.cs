using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerInputSettings : MonoBehaviour
{
    private void Awake()
    {
        PlayerInputSettings.LoadSettings(); // TODO: put in UI manager script
    }
}
