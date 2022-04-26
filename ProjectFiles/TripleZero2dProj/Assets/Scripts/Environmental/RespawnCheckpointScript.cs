using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheckpointScript : MonoBehaviour
{
    // stores variables for player 1
    [HideInInspector] public Vector3 spawnPoint1;

    // stores variables for player 2
    [HideInInspector] public Vector3 spawnPoint2;

    // stores both players for further use
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        // sets both players starting points
        spawnPoint1 = player1.transform.position;
        spawnPoint2 = player2.transform.position;
    }

    public void Update()
    {
        
    }
}
