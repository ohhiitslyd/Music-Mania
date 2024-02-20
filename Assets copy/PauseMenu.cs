using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false; //play any music 
        pauseMenu.SetActive(false); //show the pause menu
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //when esc key is pressed
        {
            pauseGame(); //pause
        }
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true); //show the pause overlay
        AudioListener.pause = true; //pause any music
        Time.timeScale = 0f; //game timer will stop
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false); //close the pause overlay
        AudioListener.pause = false; //resume any music
        Time.timeScale = 1f; //resume game timer
    }

    public void quitGame()
    {
        Application.Quit(); //quit application
    }
}
