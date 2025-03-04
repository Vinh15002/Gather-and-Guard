using System;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    private EnemyMovement enemyMovement;
    private Animator animator;
    public bool isAttack = false;
    public Transform Target => target;
    protected Transform target;
    

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();

    }


    protected void Update()
    {
        
        ChangeState();
    }

    protected void ChangeState()
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
                enemyMovement.SetDirection(target.position- this.transform.position);
                animator.SetBool("IsMove", true);
            }
            else
            {
                animator.SetBool("IsMove", false);
            }
        }
       
    }
    public void SetTarget(Transform transPlayer)
    {

        if(transPlayer != null)
        {
            target = transPlayer;
            enemyMovement.SetDirection(target.position - this.transform.position);
        }
        else
        {
            target = null;
            enemyMovement.SetDirection(Vector3.zero);
        }
    }



}