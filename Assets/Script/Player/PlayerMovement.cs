using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{

   

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

        Movement();
    }

  

    private void Movement()
    {
      
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
