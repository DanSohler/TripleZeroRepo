using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    //Upon colliding with a player, it set's their active state as false. Will edit later to 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
    }

}
