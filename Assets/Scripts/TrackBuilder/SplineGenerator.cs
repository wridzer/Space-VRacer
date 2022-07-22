using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineGenerator : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float t;

    public GameObject objA, objB, objC, objD;

    public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return a + (b - a) * t;
    }

    public static Vector3 QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 p0 = Lerp(a, b, t);
        Vector3 p1 = Lerp(b, c, t);
        return Lerp(p0, p1, t);
    }

    public static Vector3 CubicCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 p0 = QuadraticCurve(a, b, c, t);
        Vector3 p1 = QuadraticCurve(b, c, d, t);
        return Lerp(p0, p1, t);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(CubicCurve(objA.transform.position, objB.transform.position, objC.transform.position, objD.transform.position, t), 1f);
    }
}
