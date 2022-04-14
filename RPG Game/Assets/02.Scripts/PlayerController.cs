using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cam;
    private Transform tr;
    private PlayerMove playerMove;
    private Animator ani;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        playerMove = GetComponent<PlayerMove>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        ani.SetFloat("h", h);
        ani.SetFloat("v", v);

        tr.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
        playerMove.SetMove(cam.rotation * new Vector3 (h,0,v));
    }
}
