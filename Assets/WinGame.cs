using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public GameObject level1Script;
    public GameObject level2Script;
    public GameObject level3Script;

    // Update is called once per frame
    void Update()
    {
        if (level1Script.GetComponent<GameLogicScript>().completed == true && level2Script.GetComponent<GameLogicScript>().completed == true && level3Script.GetComponent<GameLogicScript>().completed == true) //if all 8 boxes are green in each level
        {
            StartCoroutine(Win());
        }
    }

    private IEnumerator Win() //resets the board if a mistake is made
    {
        //level3Script.GetComponent<GameLogicScript>().winLevel();
        yield return new WaitForSeconds(1); //wait a second to show the particles on the third platform
        
        SceneManager.LoadScene(2); //load the end scene
    }
}
