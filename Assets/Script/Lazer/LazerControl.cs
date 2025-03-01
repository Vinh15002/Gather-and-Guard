using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerControl : MonoBehaviour
{
    public Transform target; 
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; 
        lineRenderer.enabled = false; 
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)){
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position); 
            lineRenderer.SetPosition(1, target.position);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            lineRenderer.enabled = false;
        }
    }
}
