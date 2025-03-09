using System;
using UnityEngine;

namespace Script.Bullet
{
    public class BulletDamage:MonoBehaviour
    {
        private int damage;
        private string targetName;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(targetName))
            {
                Debug.Log("Hit target");
            }
        }


        public void SetTarget(int damage, string targetName)
        {
            this.damage = damage;
            this.targetName = targetName; 
        }
    }
}