using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitGate : MonoBehaviour
{
    public string levelName;
    public GameObject Player;

    //Note: Exit Gate must be large enough to interact with player
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Exit touched by " + other.name);
        if (other.gameObject == Player)
        {
            Debug.Log("Loading Next Level");
            SceneManager.LoadScene(levelName);
        }
    }
}


