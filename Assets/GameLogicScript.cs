using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameLogicScript : MonoBehaviour
{
    private List<int> clipOrder; //list to store the order of the clips
    public List<GameObject> cubes = new List<GameObject>(); //list of cubes on the platform
    public GameObject fullClipCube; //cube that will play the full audio clip in the center of the platform
    public List<AudioClip> audioClips = new List<AudioClip>();
    public int count; 
    public GameObject player;
    public GameObject floor; //get floor of the platform in order to access the center of that platform using the floor's position
    public int numCorrect; //keep track of score
    public ParticleSystem particles;
    public bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        if (particles.isPlaying)
        {
            particles.Stop();
        }
        numCorrect = 0;
        count = -1;
        clipOrder = new List<int>();
        clipOrder.Add(0);
        clipOrder.Add(1);
        clipOrder.Add(2);
        clipOrder.Add(3);
        clipOrder.Add(4);
        clipOrder.Add(5);
        clipOrder.Add(6); 
        clipOrder.Add(7);
        
        clipOrder = clipOrder.OrderBy(i => Random.value).ToList(); //randomize the order

        for (int i = 0; i < cubes.Count; i++) //assign each cube on the platform to have a random audio based on the clipOrder
        {
            cubes[i].GetComponent<AudioSource>().clip = audioClips[clipOrder[i]];
        }
    }

    public void resetGame()
    {
        numCorrect = 0; //reset score count
        foreach (GameObject cube in cubes) //make each cube white
        {
            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.white);
        }

        player.transform.position = new Vector3(floor.transform.position.x, floor.transform.position.y + 1, floor.transform.position.z); //place the player back to the center of the platform they were just on
    }

    private void Update()
    {
        winLevel();
    }

    public void winLevel()
    {
        if (numCorrect == 8)
        {
            completed = true;
            if (!particles.isPlaying)
            {
                particles.Play();
            }

        }
    }

}
