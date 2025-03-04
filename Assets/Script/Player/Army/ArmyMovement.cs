using System;
using UnityEngine;

public class ArmyMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float speed;

    private ArmyPlayer units;

    private Vector3 directionMovement;

    private void Start()
    {
        units = GetComponent<ArmyPlayer>();
    }



    private void Update()
    {
        Movement();


    }

    private void Movement()
    {
        transform.Translate(directionMovement * Time.deltaTime*speed);
        foreach (SoldierController contrl in units.players)
        {
            contrl.onMove(directionMovement);
        }
    }

    public void OnMove(Vector3 direction)
    {
        directionMovement = direction;
        //transform.Translate(direction*Time.deltaTime);
    }


}