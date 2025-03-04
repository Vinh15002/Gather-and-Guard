using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float rangeAttack = 5f;
    [SerializeField] private LayerMask enemyLayer;

    private void Update()
    {
        CheckAttack();
    }

    private void CheckAttack()
    {
        var hit = Physics.OverlapSphere(transform.position, rangeAttack, enemyLayer);
        if(hit.Length > 0)
        {
            OnAttack();
        }
    }



    private void OnAttack()
    {
        Debug.Log("Attack");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}