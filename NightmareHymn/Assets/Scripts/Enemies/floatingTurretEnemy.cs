using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingTurretEnemy : BaseEnemy
{
    public float SafetyDistance;
    private Transform playerTransform;
    private float distance;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        speed = 2;
        playerTransform = player.GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);

        Debug.Log(distance);
        //moving towards player
        if (distance > SafetyDistance)
        {
            rb.constraints = ~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY;

            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY; 
        }
    }

    void OnCollisionEnter(Collision collision)
    {

  
    }
}