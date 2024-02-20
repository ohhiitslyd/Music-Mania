using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void play() //play button will load the game
    {
        SceneManager.LoadScene(1);
    }

    public void quitButton() //quit button will exit the application
    {
        Application.Quit();
    }
}
