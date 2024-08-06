using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Player;
    public Transform spawnPoint;

    void Start()
    {
        //Check that spawnPoint and Player object are correctly assigned
        if (spawnPoint != null && Player != null)
        {
            //Set player to spawn point
            Debug.Log("Spawning Player...");
            Player.transform.position = spawnPoint.position;
            Player.transform.rotation = spawnPoint.rotation;
        }
        else
        {
            Debug.LogError("Spawn Point or Player is not assigned in the SpawnManager.");
        }
    }
}
