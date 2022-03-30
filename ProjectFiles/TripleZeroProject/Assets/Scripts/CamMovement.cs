using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    private float y, distAway;

    private float x, z;

    // Distance calculations for camera
    void Update()
    {
        z = -distAway / 90;
        x = distAway - (distAway/90);

        transform.position = new Vector3(player.transform.position.x + x, player.transform.position.y + y, player.transform.position.z + z);
        transform.LookAt(player.transform.position);
    }
}
