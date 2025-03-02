using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MonoBehaviour
{
    // Target the gun will aim at
    public Transform go_target;

    // GameObjects to control rotation and aiming
    public Transform go_baseRotation;
    public Transform go_GunBody;
    public Transform go_barrel;

    // Gun barrel rotation
    public float barrelRotationSpeed;
    private float currentRotationSpeed;

    // Distance the turret can aim and fire from
    public float firingRange;

    // Particle system for the muzzle flash
    public ParticleSystem muzzleFlash;

    // Used to start and stop the turret firing
    public bool canFire = false;

    void Start()
    {
        // Set the firing range distance
        SphereCollider collider = this.GetComponent<SphereCollider>();
        if (collider != null)
        {
            collider.radius = firingRange;
        }
    }

    void Update()
    {
        AimAndFire();
    }

    // void OnDrawGizmosSelected()
    // {
    //     // Draw a red sphere at the transform's position to show the firing range
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, firingRange);
    // }

    // Detect an enemy, aim and fire
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Enemy"))
    //     {
    //         go_target = other.transform;
    //         canFire = true;
    //     }
    // }

    // // Stop firing
    // void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Enemy"))
    //     {
    //         canFire = false;
    //         go_target = null; // Reset target when exiting
    //     }
    // }
    
    void AimAndFire()
    {
        // Gun barrel rotation
        go_barrel.transform.Rotate(0, 0, currentRotationSpeed * Time.deltaTime);

        if (canFire)
        {
            // Start rotation
            currentRotationSpeed = barrelRotationSpeed;

            // Aim at enemy
            if (go_target != null)
            {
                Vector3 baseTargetPosition = new Vector3(go_target.position.x, transform.position.y, go_target.position.z);
                Vector3 gunBodyTargetPosition = go_target.position;

                go_baseRotation.LookAt(baseTargetPosition);
                go_GunBody.LookAt(gunBodyTargetPosition);

                // Start particle system 
                if (!muzzleFlash.isPlaying)
                {
                    muzzleFlash.Play();
                }
            }
        }
        else
        {
            // Slow down barrel rotation and stop
            currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0, 10 * Time.deltaTime);

            // Stop the particle system
            if (muzzleFlash.isPlaying)
            {
                muzzleFlash.Stop();
            }
        }
    }
}