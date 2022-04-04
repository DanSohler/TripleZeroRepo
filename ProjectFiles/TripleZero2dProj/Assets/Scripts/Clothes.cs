using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    private PlayerMovement pms;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent <PlayerMovement>();
            pms.canInteract = true;
            pms.interactObject = this.gameObject;
            //Debug.Log("Kris why won't this work");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent<PlayerMovement>();
            pms.canInteract = false;
            pms.interactObject = null;
            //Debug.Log("You expect me to know?");
        }
    }
}
