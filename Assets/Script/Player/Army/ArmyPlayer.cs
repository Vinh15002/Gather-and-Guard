
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmyPlayer : MonoBehaviour
{


    public GameObject playerPrefab;
    public List<PlayerController> players;


   
    [SerializeField] private PlayerUI playerUI;
    private ArmyMovement armyMovement;

    


    private void Start()
    {
        playerUI = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
        armyMovement = GetComponent<ArmyMovement>();
        playerUI.Initialize(armyMovement);
        players = new List<PlayerController>();
        foreach(Transform t in transform)
        {
            if (t.gameObject.CompareTag("Player"))
            {
                players.Add(t.GetComponent<PlayerController>());
            }
        }
        SetHorizontal();
    }


    private void OnEnable()
    {
        PlayerEvent.addPlayer += AddPlayer;
    }

    private void OnDisable()
    {
        PlayerEvent.addPlayer -= AddPlayer;
    }

    private void AddPlayer(Vector3 postion)
    {
        GameObject game =  Instantiate(playerPrefab, postion, Quaternion.identity, transform);
        players.Add(game.GetComponent<PlayerController>());
        SetHorizontal();
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
    public void Triangle()
    {
        List<Vector3> lineup = ArmyFormation.Triangle(players.Count);
        
        for (int i = 0; i < lineup.Count; i++)
        {

            players[i].SetPostion(lineup[i]);


        }
    }

}