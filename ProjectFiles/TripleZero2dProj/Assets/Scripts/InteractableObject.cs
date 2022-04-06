using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private PlayerMovement pms;
    [SerializeField]
    private bool isButton;
    [SerializeField]
    private GameObject Object1 = null;
    [SerializeField]
    private GameObject Object2 = null;
    private bool ObjectActive1 = true;
    private bool ObjectActive2 = true;


    private float resetDelay;

    private void Update()
    {
        if (resetDelay > 0)
        {
            resetDelay -= Time.deltaTime;
        }
        if (isButton == true && resetDelay <= 0)
        {
            if (Object1 != null)
            {
                Object1.SetActive(ObjectActive1);
            }
            if (Object2 != null)
            {
                Object1.SetActive(ObjectActive2);
            }
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
        if (isButton == false && resetDelay <= 0)
        {

            //Debug.Log("Yeet");

            resetDelay = 0.5f;

            if (Object1 != null)
            {
                Object1.SetActive(!ObjectActive1);
                ObjectActive1 = (!ObjectActive1);
            }
            if (Object2 != null)
            {
                Object1.SetActive(!ObjectActive2);
                ObjectActive2 = (!ObjectActive2);
            }

        }
        else if (isButton == true && resetDelay <= 0)
        {
            if (Object1 != null)
            {
                Object1.SetActive(!ObjectActive1);
            }
            if (Object2 != null)
            {
                Object1.SetActive(!ObjectActive2);
            }

            resetDelay = 0.2f;
        }

    }
}
