using System;
using UnityEngine;

namespace Script.Boss.Dragon
{
    public class BreathDealDamge : DealDamage
    {
        private float timeDealDamage = 1f;

        private void FixedUpdate()
        {
            if (timeDealDamage > 0)
            {
                timeDealDamage -= Time.deltaTime;
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (timeDealDamage < 0 && other.CompareTag("Player"))
            {
                Debug.Log("Dealing damage");
                timeDealDamage = 1f;
            }
        }

        // private void OnParticleCollision()
        // {

        // }
    }
}