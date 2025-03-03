using System;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    private EnemyMovement enemyMovement;

    private Animator animator;


    public bool isAttack = false;
    

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();

    }


    protected void Update()
    {
        ChangeAnimation();
    }

    protected void ChangeAnimation()
    {
        if(isAttack)
        {
            animator.SetBool("IsAttack", true);
            enemyMovement.SetDirection(Vector3.zero);
        }
        else
        {
            animator.SetBool("IsAttack", false);
            if (target != null)
            {
                animator.SetBool("IsMove", true);
            }
            else
            {
                animator.SetBool("IsMove", false);
            }
        }
       
    }

    public Transform Target => target;
    protected Transform target;
    public void SetTarget(Transform transform)
    {
        if(transform != null)
        {
            target = transform;
            enemyMovement.SetDirection(target.position - transform.position);
        }
        else
        {
            target = null;
            enemyMovement.SetDirection(Vector3.zero);
        }
    }



}