using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private PlayerMovement pms;
    [SerializeField]
    private bool isButton;

    private float resetDelay;

    private void Update()
    {
        if (resetDelay > 0)
        {
            resetDelay -= Time.deltaTime;
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent<PlayerMovement>();
            pms.canInteract = true;
            pms.interactObject = this.gameObject;
            pms.IOs = this.GetComponent<InteractableObject>();
            //Debug.Log(pms.IOs + " - " + this.GetComponent<InteractableObject>());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pms = collision.gameObject.GetComponent<PlayerMovement>();
            pms.canInteract = false; 
            pms.interactObject = null;
            pms.IOs = null;
        }
    }

    public void Activate ()
    {
        if (resetDelay <= 0)
        {
            //Debug.Log("Yeet");

            resetDelay = 0.5f;
        }
    }
}
