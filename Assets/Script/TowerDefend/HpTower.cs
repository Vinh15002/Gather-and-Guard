using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HpTower : MonoBehaviour, IHealth 
{
    [SerializeField] private int hp = 1000;

    public void Damage(int dame)
    {
        hp -= dame;
    }
    public void Heal()
    {
        throw new System.NotImplementedException();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon")){
            // Damage();
        }
    }

    public void Destroyed(){
        
    }

}
