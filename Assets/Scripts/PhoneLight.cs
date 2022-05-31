using System.Collections;
using UnityEngine;

public class PhoneLight : MonoBehaviour
{

    [HideInInspector] public bool flash;
    private Light phoneLight;

    // Use this for initialization
    void Start()
    {
        phoneLight = GetComponent<Light>();
        phoneLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flash)
        {
            StartCoroutine(FlashOn());
        }
    }

    private IEnumerator FlashOn()
    {
        yield return new WaitForSeconds(0.5f);
        phoneLight.enabled = true;
        StartCoroutine(FlashOff());
    }

    private IEnumerator FlashOff()
    {
        yield return new WaitForSeconds(0.5f);
        phoneLight.enabled = false;    }
}