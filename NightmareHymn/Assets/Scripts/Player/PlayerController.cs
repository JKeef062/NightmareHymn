using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;             // Movement speed of the player
    public int health;                  // Maintains player health
    public float jumpForce;             // Force of player jump
    int jumpCount;                      // Number of jumps performed in one airborne state
    public int maxJumps;                // Max allowed jumps in each airborne state
    public Rigidbody theRB;             // Reference to player RigidBody component
    public float airMovement;           // How much control player has in the air
    float startSpd;                     
    bool inAir;                         // True if the player is not touching a floor
    public float gravity;               // Custom gravity scale for player
    bool running;                       // True if the player is running
    private Vector2 moveDirection;      // Vector representign movement direction of player
    public float horizAxis;             // Holds a value representing the left/right controller input
    public float fallingGravScale;      // Scalar of how much increased gravity is applied when player is falling
                                        


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        maxJumps = 2;
        startSpd = moveSpeed;
        running = false;
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // Get controller horizontal direction
        horizAxis = Input.GetAxisRaw("Horizontal");


        // Handle player jumping
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            jumpCount += 1;
        }

        /*if (Input.GetButtonUp("Jump"))
        {
            theRB.velocity = new Vector2(theRB.velocity.x, 0);
        }*/


        // Handle player death
        if(isDead() == true)
        {
            FindObjectOfType<GameManager>().EndGame();
        }


        // Handle airborne movement and increased fall gravity
        if (inAir == true)
        {
            // Reduce allowed movement speed while player is in the air
            moveSpeed = airMovement * startSpd;

            // Increase the gravity if the player is falling
            if (theRB.velocity.y < 0)
            {
                theRB.velocity -= Vector3.up * gravity * (fallingGravScale - 1) * Time.deltaTime;
            }
        }
        else
        {
            moveSpeed = startSpd;
        }


        // Apply custom gravity scale to player
        theRB.AddForce(Vector2.down * gravity * theRB.mass);


        // Move the player according to the horizontal controller input
        theRB.velocity = new Vector2(horizAxis * moveSpeed, theRB.velocity.y);
    }

    // Handle player collision
    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Player hit: " + other.gameObject.tag);

        // Handle player hitting instant death trap
        if (other.gameObject.CompareTag("DeathTrap"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        // Handle player landing from airborne state
        if (other.gameObject.tag == "Floor")
        {
            jumpCount = 0;
            inAir = false;
        }

        
    }

    void OnCollisionExit(Collision other)
    {

        // Handle leaving the ground
        if (other.gameObject.CompareTag("Floor"))
        {
            inAir = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Take damage if hit by enemy projectile
        if (other.gameObject.CompareTag("Enemybullet"))
        {
            health -= 1;
        }
    }


    // Signal if player has run out of health
    bool isDead()
    {
        if(health <= 0)
        {
            return(true);
        }
        else
        {
            return (false);
        }
    }

}
