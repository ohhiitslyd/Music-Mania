using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLogic : MonoBehaviour
{
    public Renderer cubeRenderer;
    public Color redColor;
    public Color greenColor;
    public bool onButton = false; //see whether player is currently on this cube
    public GameObject gameLogicScript; //to access the ordered lists in GameLogic objects

    private void Start()
    {
        cubeRenderer = gameObject.GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Player") //if the collider is the player (and not, for example, the floor)
        {
            onButton = true; //detect that the player has entered the button
            GetComponent<AudioSource>().Play(); //play the clip of the button
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            onButton = false; //detect that the player is no longer on the button
            GetComponent<AudioSource>().Stop(); //stop playing that button's clip once player is no longer on it
        }

    }

    private void Update()
    {
        if (onButton && gameObject.tag != "Full Clip") //if player is on the button
        {
            if (cubeRenderer.material.color != greenColor && Input.GetKeyDown(KeyCode.E)) //if it's not already selected green and the player presses 'e'
            {
                gameLogicScript.GetComponent<GameLogicScript>().count += 1;
                if (gameObject.GetComponent<AudioSource>().clip == gameLogicScript.GetComponent<GameLogicScript>().audioClips[gameLogicScript.GetComponent<GameLogicScript>().count])
                {
                    cubeRenderer.material.SetColor("_Color", greenColor); //change the color of the button to green if it is the next one in the order
                    gameLogicScript.GetComponent<GameLogicScript>().numCorrect += 1;
                }
                else
                {
                    cubeRenderer.material.SetColor("_Color", redColor); //change the color of the button to red if the selection is incorrect
                    StartCoroutine(ResetGame());
                    
                }
            }
        }
        

    }

    private IEnumerator ResetGame() //resets the board if a mistake is made
    {
        yield return new WaitForSeconds(1); //wait a second to show that the selection was wrong, then continue to restart
        gameLogicScript.GetComponent<GameLogicScript>().count = -1; //reset the count variable
        gameLogicScript.GetComponent<GameLogicScript>().resetGame(); //reset the game

    }
}
