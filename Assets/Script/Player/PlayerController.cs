using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public void onMove(Vector3 directionMovement)
    {
        playerMovement.OnMove(directionMovement);
    }

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
  
        
    }

    public void SetPostion(Vector3 postion)
    {

        this.transform.DOLocalMove(postion, 1f);
        
        

    }

   
}