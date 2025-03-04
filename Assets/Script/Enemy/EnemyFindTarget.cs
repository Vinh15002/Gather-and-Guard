using UnityEngine;

public class EnemyFindTarget : MonoBehaviour
{




    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            GetComponentInParent<EnemyControl>().SetTarget(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponentInParent<EnemyControl>().SetTarget(null);
        }
    }
}