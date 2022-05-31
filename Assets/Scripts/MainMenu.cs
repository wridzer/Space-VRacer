using System.Collections;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject phoneNormal, phoneListner, UILineR, UILineL, phoneHolder1, phoneHolder2;

    public void StartGame()
    {
        //start phones ring
        phoneNormal.GetComponent<PhoneManager>().enabled = true;
        phoneListner.GetComponent<ListnerPhone>().enabled = true;
        phoneListner.GetComponent<PhoneManager>().enabled = true;
        phoneHolder1.GetComponent<PhoneHolder>().enabled = true;
        phoneHolder2.GetComponent<PhoneHolder>().enabled = true;
        phoneHolder1.GetComponent<SphereCollider>().enabled = true;
        phoneHolder2.GetComponent<SphereCollider>().enabled = true;
        UILineL.SetActive(false);
        UILineR.SetActive(false);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}