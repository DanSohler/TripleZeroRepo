using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public CharacterController2D pms;
    public GameObject playerObj;

    //Upon colliding with a player, it set's their active state as false. Will edit later to 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //collision.gameObject.SetActive(false);
            playerObj.gameObject.transform.position = pms.respawnPoint;
        }
        else if (collision.transform.tag == "Checkpoint")
        {
            pms.respawnPoint = playerObj.gameObject.transform.position;
        }

    }

}
