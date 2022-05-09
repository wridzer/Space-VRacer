using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public Renderer[] lights;

    //Note: This assumes that Checkpoints are instantiated AFTER the GameplayManager has been instantiated. Using Start breaks things.
    //Might have to be changed based on how we do things
    private void Awake()
    {
        GameplayManager.Instance.SetStartBlock(this);
    }

    public void SetLight(int light, Color color)
    {
        //set lights of start block
        lights[light].material.color = color;
    }

    public void SetLights(Color color)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            SetLight(i, color);
        }
    }
}
