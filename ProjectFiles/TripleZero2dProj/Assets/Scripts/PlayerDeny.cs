using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeny : MonoBehaviour
{
    public string playerToDeny = "TestPlayer";
    [SerializeField]
    private BoxCollider2D bC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (playerToDeny == collision.gameObject.name)
            {
                bC.isTrigger = true;
            }
            //Debug.Log("In");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (playerToDeny == collision.gameObject.name)
            {
                bC.isTrigger = false;
            }
            //Debug.Log("Away");
        }
    }
}
