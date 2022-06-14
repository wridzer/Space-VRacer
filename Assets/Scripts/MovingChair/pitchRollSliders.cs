using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Ports;
using System.Threading;

public class pitchRollSliders : MonoBehaviour
{
    [SerializeField] private GameObject playerInstance;
    private Rigidbody rb;
    [SerializeField] private float multiply;
    public Vector3 localAngularVelocity;

    SerialPort sp = new SerialPort("COM3", 115200);
    public float time_interval = 1f;
    float next_time = 0.1f;
    int time;
    public bool send = false;

    //public TMP_Text pitchText;
    //public Slider pitchSlider;

    //public TMP_Text rollText;
    //public Slider rollSlider;

    //public TMP_Text lMotorText;
    //public TMP_Text rMotorText;
    private float lPos;
    private float rPos;

    string[] ports = SerialPort.GetPortNames();


    // Start is called before the first frame update
    void Start()
    {
        rb = playerInstance.GetComponent<Rigidbody>();
        if (!sp.IsOpen)
        {
            Thread sampleThread = new Thread(new ThreadStart(sampleFunction));
            sampleThread.IsBackground = true;
            sampleThread.Start();
            sp.Open();
            //sp.ReadTimeout = 100;
            //sp.WriteTimeout = 10;
            //sp.Handshake = Handshake.None;
            if (sp.IsOpen) { print("Open"); }
        }

        Debug.Log(ports);
    }

    // Update is called once per frame
    void Update()
    {
        //pitchText.text = "Pitch: " + pitchSlider.value;
        //rollText.text = "Roll: " + rollSlider.value;


        //lPos = pitchSlider.value + rollSlider.value;
        //rPos = 180 - pitchSlider.value + rollSlider.value;   //voor de servo prototype moet het 180 zijn, voor motors 1023
        // localAngularVelocity = transform.InverseTransformDirection(rb.angularVelocity);

        lPos = (localAngularVelocity.x + localAngularVelocity.z) * multiply;
        rPos = 180 - (localAngularVelocity.x + localAngularVelocity.z) * multiply;   //voor de servo prototype moet het 180 zijn, voor motors 1023

        if (lPos >= 1023) { lPos = 1023; }
        if (lPos <= 0) { lPos = 0; }

        if (rPos >= 1023) { rPos = 1023; }
        if (rPos <= 0) { rPos = 0; }

        //lMotorText.text = lPos.ToString();
        //rMotorText.text = rPos.ToString();


        if (Time.time > next_time)
        {
            if (!sp.IsOpen)
            {
                sp.Open();
                print("opened sp");
            }
            if (sp.IsOpen)
            {
                // print("Writing " + ii);
               // sp.WriteLine("<" + lPos + "," + rPos + ">");  //("/" + lPos + "," + rPos + "~");
               // Debug.Log("<" + lPos + "," + rPos + "> " + Time.time);
                send = true;
            }
            next_time = Time.time + time_interval;
        }
    }

    public void sampleFunction()
    {
        while (true)
        {

            if (sp.IsOpen)
            {
                //lezen joyx






                if (send == true) { 
                    sp.WriteLine("<" + lPos + "," + rPos + ">");  //("/" + lPos + "," + rPos + "~");
                    send = false;
                    
                    Debug.Log("<" + lPos + "," + rPos + ">");
                }

            }
        }
    }
}

