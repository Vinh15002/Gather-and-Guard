
using System.Collections.Generic;
using UnityEngine;

public class ArmyPlayer : MonoBehaviour
{
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
    }


    public void AddPlayer(Transform player)
    {
        player.transform.parent = transform;
        players.Add(player.GetComponent<PlayerController>());
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