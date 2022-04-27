using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableSurface : MonoBehaviour
{
    private PlayerMovement pms;
    [SerializeField]
    private bool isRope;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent<PlayerMovement>();
            pms.canClimb = true;
            pms.isRope = isRope;
            //Debug.Log("In");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent<PlayerMovement>();
            pms.canClimb = false;
            pms.isRope = false;
            //Debug.Log("Away");
        }
    }
}
