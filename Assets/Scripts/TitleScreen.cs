using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    //Pressing Start Button
    public void OnStartButton(){  
        if (Input.GetKey(KeyCode.D)){
            Cursor.visible = false;
            SceneManager.LoadScene("DevRoom"); //If holding "d", enter Dev Room
        } else {
            SceneManager.LoadScene("Maze"); //Else, enter first level
        }
    }
    //Prssing Quit Button
    public void OnQuitButton(){
        Application.Quit(); //Quit Game
    }
}
