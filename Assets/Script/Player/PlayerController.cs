using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField]private PlayerUI playerUI;



    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
  
        playerUI  = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();   
        playerUI.Initialize(playerMovement);
    }
}