using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
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
        //GetInput();


        Movement();
    }

    private void GetInput()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        directionMovement = new Vector3(dirX,0, dirZ);

    }

    private void Movement()
    {
        rb.velocity = directionMovement*speed;
        bool isMove = directionMovement.magnitude > 0.2f;
        animator.SetBool("IsRun", isMove);
        if(isMove)
        {
            Quaternion rotate = Quaternion.LookRotation(directionMovement);
            rb.rotation = rotate;
        }
    }

    public void OnMove(Vector3 direction)
    {
       
        directionMovement = direction;
    }
}
