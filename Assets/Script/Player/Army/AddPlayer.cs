using UnityEngine;

public  class AddPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            other.GetComponent<ArmyPlayer>().AddPlayer(transform.parent);
        }
    }
}