using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPlacer : MonoBehaviour
{
    public float spacing = .1f, resolution = 1;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] points = FindObjectOfType<TrackBuilder.PathCreator>().path.CalculateEvenlySpacedPoints(spacing, resolution);
        foreach (Vector3 p in points)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            g.transform.position = p;
            g.transform.localScale = Vector3.one * spacing * .5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
