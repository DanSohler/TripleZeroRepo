using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakerPlatform : MonoBehaviour
{
    private float deathTimer = 5f;

    // Update is called once per frame
    void Update()
    {
        deathTimer -= Time.deltaTime;

        if (deathTimer < 0)
        {
            Destroy(this.GetComponentInChildren<GameObject>());
            Destroy(this.gameObject);
        }
    }
}
