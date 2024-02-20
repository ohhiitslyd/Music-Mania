using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rb;
    private float xRange;
    private Vector3 center1 = new Vector3(0,0.36f,0); //center of platform 1
    private Vector3 center3 = new Vector3(9.32f, 3.97f, 0); //center of platform 3
    private float zRange;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        transform.position = new Vector3(0, 1, 0); //start in the middle, in case it's not already there
        xRange = 2.22f;
        zRange = 2.22f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //move player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); //move forward at given speed
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput); //move right at given speed

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //jump with given force
        }

        //keeping player within the boundaries of the floor

        //x-boundaries
        if (transform.position.x > center3.x + xRange) //if player tries to move to the right edge of the 3rd platform
        {
            transform.position = new Vector3(center3.x + xRange, transform.position.y, transform.position.z); //player is continuously replaced on the edge of the platform
        }
        if (transform.position.x < center1.x - xRange) //if player tries to move to the left edge of the 1st platform
        {
            transform.position = new Vector3(center1.x - xRange, transform.position.y, transform.position.z); //player is continuously replaced on the edge of the platform
        }
        

        //z-boundaries
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange); //player is continuously replaced on the edge of the platform
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange); //player is continuously replaced on the edge of the platform
        }


    }
}
