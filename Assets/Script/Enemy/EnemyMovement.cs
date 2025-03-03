using System;
using UnityEngine;

public  class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float speed;



    protected Vector3 direction = Vector3.zero;


    protected virtual void Update()
    {
        OnMove();
    }
    protected virtual void OnMove() {
        
        transform.Translate(direction*Time.deltaTime*speed);
    }

    public void SetDirection(Vector3 vector3)
    {
        direction = vector3.normalized;
    }
}