using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackyTracky : MonoBehaviour
{
    public GameObject tracky;

    public float incline, distance;
    public int cubeAmount;

    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = null;

        cube = Instantiate(tracky, transform.position, transform.rotation, transform);

        for (float i = 0; i < cubeAmount; i++)
        {
            Vector3 pos = cube.transform.position + (cube.transform.forward * distance);
            Quaternion rot = Quaternion.Euler((incline / cubeAmount) * i, 0, 0);

            cube = Instantiate(tracky, pos, rot, transform);

            cube.transform.localRotation = rot;
        }
    }
}
