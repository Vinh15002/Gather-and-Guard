using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public void onMove(Vector3 directionMovement)
    {
        playerMovement.OnMove(directionMovement);
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
  
        
    }


    public void SetPostion(Vector3 postion)
    {
        this.transform.localPosition = postion;
    }

}