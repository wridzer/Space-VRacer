using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour
{
    //Note: This assumes that Checkpoints are instantiated AFTER the GameplayManager has been instantiated. Using Start breaks things.
    //Might have to be changed based on how we do things
    private void Awake()
    {
        GameplayManager.Instance.SetStartBlock(this);
    }
}
