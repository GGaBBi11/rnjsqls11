using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPorint : MonoBehaviour
{
    public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
            points[i] = transform.GetChild(i);
    }

    public static bool TryNextWayPoint(int currentPointIndex, out Transform nextWayPoint)
    {
        nextWayPoint = null;
        bool isOK = false;
        if (points.Length -1 > currentPointIndex)
        {
            nextWayPoint = points[currentPointIndex + 1];
            isOK = true;
        }
        return isOK;
    }
}
