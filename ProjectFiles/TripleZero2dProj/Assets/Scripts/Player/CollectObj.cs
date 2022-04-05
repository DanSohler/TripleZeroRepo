using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObj : MonoBehaviour
{
    private Object currentObj;

    private void Awake()
    {
        currentObj = GetComponent<Object>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(currentObj.Id, PlayerPrefs.GetInt(currentObj.Id) + 1);
            Destroy(gameObject);
        }

    }
}
