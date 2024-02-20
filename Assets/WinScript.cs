using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public void playAgain() //play again button will reload the play scene
    {
        SceneManager.LoadScene(1);
    }

    public void quitButton() //quit the application
    {
        Application.Quit();
    }
}
