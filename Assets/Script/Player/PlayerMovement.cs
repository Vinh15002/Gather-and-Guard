using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody rb;
    private Animator animator;


    private Vector3 directionMovement;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        GetInput();


        OnMove();
    }

    private void GetInput()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        directionMovement = new Vector3(dirX,0, dirZ);

    }

    private void OnMove()
    {
        rb.velocity = directionMovement*speed;
    }
}
