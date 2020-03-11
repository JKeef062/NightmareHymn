using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    int jumpCount;
    public int maxJumps;
    public Rigidbody theRB;
    public float airMovement;
    float startSpd;
    bool inAir;
    public float gravity;
    bool running;
    private Vector2 moveDirection;
    public float horizAxis;                // Holds a value representing the 
                                        //vertical axis on controller


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        maxJumps = 2;
        startSpd = moveSpeed;
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get controller horizontal axis
        horizAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            jumpCount += 1;
            
        }

        if (inAir == true)
        {
            moveSpeed = airMovement * startSpd;
        }
        else
        {
            moveSpeed = startSpd;
        }

        // Gravity
        theRB.AddForce(Vector2.down * gravity * theRB.mass);

        // Movement
        theRB.velocity = new Vector2(horizAxis * moveSpeed, theRB.velocity.y);
    }

    // Handle player collision
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "DeathTrap")
        {
            Debug.Log("Player Died");
            Application.Quit();
        }

        if(other.gameObject.tag == "Floor")
        {
            Debug.Log("Player hit: " + other.gameObject.tag);
            jumpCount = 0;
            inAir = false;
        }
    }
    
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            inAir = true;
        }
    }
}
