using System;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    public GameObject player;
    public int JumpPos;

    private Rigidbody rb;
    private bool IsJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsJumping = false;
    }

    private void Update()
    {
        
    }

    private void Jump()
    {

    }

}

