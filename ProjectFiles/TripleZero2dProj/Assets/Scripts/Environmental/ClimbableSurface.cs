using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableSurface : MonoBehaviour
{
    private PlayerMovement pms;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent<PlayerMovement>();
            pms.canClimb = true;
            //Debug.Log("In");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent<PlayerMovement>();
            pms.canClimb = false;
            //Debug.Log("Away");
        }
    }
}
