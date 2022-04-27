using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRope : MonoBehaviour
{
    [SerializeField]
    private GameObject theRope;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            theRope.SetActive(true);
        }
    }
}
