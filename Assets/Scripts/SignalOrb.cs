using System.Collections;
using UnityEngine;

public class SignalOrb : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Antenna")
        {
            other.transform.parent.GetComponent<Antenna>().GotAntenna(gameObject);
        }
    }
}