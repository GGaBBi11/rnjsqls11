using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    private Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = new Vector3(target.position.x - 0.5f, tr.position.y, target.position.z - 6f);
        tr.LookAt(target);
    }
}
