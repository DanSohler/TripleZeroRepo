using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    private PlayerMovement pms;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent<PlayerMovement>();
            pms.canInteract = true;
            pms.interactObject = this.gameObject;
        }
    }

    void OnCollisionExit (Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent<PlayerMovement>();
            pms.canInteract = false;
            pms.interactObject = null;
        }
    }
}
