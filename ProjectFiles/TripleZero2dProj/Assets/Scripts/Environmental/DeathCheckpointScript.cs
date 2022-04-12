using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheckpointScript : MonoBehaviour
{
    public RespawnScript respawnManager;
    [SerializeField] private bool isDeathbox;
    private bool usedPlayer1;
    private bool usedPlayer2;

    //Upon colliding with a player, it set's their active state as false. Will edit later to 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDeathbox == true)
        {
            if (collision.transform.tag == "Player")
            {
                if (collision.gameObject == respawnManager.player1)
                {
                    respawnManager.player1.transform.position = respawnManager.spawnPoint1;
                }
                else if (collision.gameObject == respawnManager.player2)
                {
                    respawnManager.player2.transform.position = respawnManager.spawnPoint2;
                }
            }
        }
    }

    // Usef for checkpoints, set respawn to exit of checkpoint
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isDeathbox == false)
        {
            if (collision.transform.tag == "Player")
            {
                if (collision.gameObject == respawnManager.player1)
                {
                    if (usedPlayer1 == false)
                    {
                        respawnManager.spawnPoint1 = gameObject.transform.position;
                        usedPlayer1 = true;
                    }
                }
                else if (collision.gameObject == respawnManager.player2)
                {
                    if (usedPlayer2 == false)
                    {
                        respawnManager.spawnPoint2 = gameObject.transform.position;
                        usedPlayer2 = true;
                    }
                }
            }
        }
    }
    
}