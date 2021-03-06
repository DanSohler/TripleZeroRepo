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
    [SerializeField]
    private GameObject Object3 = null;
    private bool ObjectActive1 = true;
    private bool ObjectActive2 = true;
    private bool ObjectActive3 = true;

    public Sprite idleSprite;
    public Sprite activeSprite;


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
                Object2.SetActive(ObjectActive2);
            }
            if (Object3 != null)
            {
                Object3.SetActive(ObjectActive3);
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
            //is lever

            resetDelay = 0.5f;

            if (Object1 != null)
            {
                Object1.SetActive(!ObjectActive1);
                ObjectActive1 = (!ObjectActive1);
            }
            if (Object2 != null)
            {
                Object2.SetActive(!ObjectActive2);
                ObjectActive2 = (!ObjectActive2);
            }
            if (Object3 != null)
            {
                Object3.SetActive(!ObjectActive3);
                ObjectActive3 = (!ObjectActive3);
            }

        }
        else if (isButton == true && resetDelay <= 0)
        {
            //is button

            if (Object1 != null)
            {
                Object1.SetActive(!ObjectActive1);
            }
            if (Object2 != null)
            {
                Object2.SetActive(!ObjectActive2);
            }
            if (Object3 != null)
            {
                Object3.SetActive(!ObjectActive3);
            }

            resetDelay = 0.20f;
        }

    }
}
