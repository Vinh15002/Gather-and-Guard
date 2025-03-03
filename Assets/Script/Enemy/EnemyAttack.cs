using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]protected float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnAttack(other.gameObject);
        }
    }

    protected virtual void OnAttack(GameObject gameObject)
    {
        GetComponentInParent<EnemyControl>().isAttack = true;
    }
}


