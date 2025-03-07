
using System;
using System.Collections.Generic;
using Script.Event;
using Script.Player.Army;
using Unity.VisualScripting;
using UnityEngine;

public class ArmyPlayer : MonoBehaviour
{


    public GameObject playerPrefab;
    public List<SoldierController> players;


   
    [SerializeField] private PlayerUI playerUI;
    private ArmyMovement armyMovement;

    
    private LineUp lineUp = LineUp.Horizontal; 
    


    private void Start()
    {
        playerUI = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
        armyMovement = GetComponent<ArmyMovement>();
        playerUI.Initialize(armyMovement);
        players = new List<SoldierController>();
        foreach(Transform t in transform)
        {
            if (t.gameObject.CompareTag("Player"))
            {
                players.Add(t.GetComponent<SoldierController>());
            }
        }
        SetHorizontal();
    }


    private void OnEnable()
    {
        PlayerEvent.addPlayer += AddPlayer;
        ArmyEvent.ChangeLineUpArmy += ChangeLineUpArmy;
    }

    private void OnDisable()
    {
        PlayerEvent.addPlayer -= AddPlayer;
        ArmyEvent.ChangeLineUpArmy += ChangeLineUpArmy;
    }

    private void AddPlayer(Vector3 postion)
    {
        GameObject game =  Instantiate(playerPrefab, postion, Quaternion.identity, transform);
    
        players.Add(game.GetComponent<SoldierController>());
        ChangeLineUpArmy(this.lineUp);
    }

    private void ChangeLineUpArmy(LineUp lineUp)
    {
        if (lineUp == LineUp.Horizontal)
        {
            SetHorizontal();
        }
        else if (lineUp == LineUp.Vertical)
        {
            SetVertical();
        }
        else if (lineUp == LineUp.Triangle)
        {
            if (players.Count <= 3) return;
            else SetTriangle();
        }
        else if (lineUp == LineUp.Rectangle)
        {
            if (players.Count <= 3) return;
            else SetRectangle();
        }

        this.lineUp = lineUp;
    }


    [ContextMenu("Horizontal")]
    public void SetHorizontal()
    {
        List<Vector3> lineup = ArmyFormation.Horizontal(players.Count);
        for(int i = 0; i < lineup.Count; i++) {
            players[i].SetPostion(lineup[i]);
        }
    }

    [ContextMenu("Vertical")]
    public void SetVertical()
    {
        List<Vector3> lineup = ArmyFormation.Vertical(players.Count);
        for (int i = 0; i < lineup.Count; i++)
        {

            players[i].SetPostion(lineup[i]);


        }
    }

    [ContextMenu("Triangle")]
    public void SetTriangle()
    {
        List<Vector3> lineup = ArmyFormation.Triangle(players.Count);
        
        for (int i = 0; i < lineup.Count; i++)
        {

            players[i].SetPostion(lineup[i]);


        }
    }

    [ContextMenu("Rectangle")]
    public void SetRectangle()
    {
        List<Vector3> lineup = ArmyFormation.Rectangle(players.Count);
        
        for (int i = 0; i < lineup.Count; i++)
        {

            players[i].SetPostion(lineup[i]);


        }
    }

}