using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    
    public Transform target; 
    public Transform startPoint;
    // public Rigidbody rb;
    public GameObject weapon;
    private Vector3 launchDirection;
    private float launchAngle = 45f; 

    void Start()
    {
        // launchDirection = CalculateLaunchDirection(target.position, launchAngle);
        // rb.velocity = launchDirection; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject wp = Instantiate(weapon,startPoint.position,Quaternion.identity);
            launchDirection = CalculateLaunchDirection(target.position, launchAngle);
            wp.GetComponent<Rigidbody>().velocity = launchDirection;
        }
    }

    Vector3 CalculateLaunchDirection(Vector3 targetPosition, float angle)
    {
        float angleRad = angle * Mathf.Deg2Rad;

        Vector3 toTarget = targetPosition - startPoint.transform.position;
        float distance = new Vector2(toTarget.x, toTarget.z).magnitude;

        float horizontalVelocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * angleRad));
        float verticalVelocity = horizontalVelocity * Mathf.Sin(angleRad);

        Vector3 launchDirection = new Vector3(toTarget.x, verticalVelocity, toTarget.z).normalized;
        return launchDirection * horizontalVelocity;
    }


}
