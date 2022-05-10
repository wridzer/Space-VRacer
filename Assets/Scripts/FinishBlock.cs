using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Just going to assume real quick that only the player can trigger things
        GameplayManager.Instance.PassFinish();
    }
}
