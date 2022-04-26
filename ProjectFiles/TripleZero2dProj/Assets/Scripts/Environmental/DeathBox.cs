using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public RespawnScript respawnManager;
    //Upon colliding with a player, it set's their active state as false. Will edit later to 
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            if (collision.gameObject == respawnManager.player1)
            {
                respawnManager.player1.transform.position = respawnManager.spawnPoint1;
            }
            else
            {
                respawnManager.player2.transform.position = respawnManager.spawnPoint2;
            }
        }
    }

}