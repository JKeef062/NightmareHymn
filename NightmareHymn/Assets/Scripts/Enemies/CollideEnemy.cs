﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideEnemy : BaseEnemy
{
    private Transform playerTransform;
    public Rigidbody rb;
    private float LorR = 0;
    public float chaseSpeed = 100;
    private bool leftstrained;
    private bool rightstrained;

    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        health = 5;
        rb = GetComponent<Rigidbody>();
        leftstrained = false;
        rightstrained = false;
}

    void FixedUpdate()
    {
        LorR = playerTransform.position.x - transform.position.x;
        
        if (LorR > 0 && rightstrained == false)
        {
            LorR = 1f;
        }
        else if (LorR < 0 && leftstrained == false)
        {
            LorR = -1f;
        }
        else
        {
            LorR = 0f;
        }

        //handles when the enemy is colliding with a constraint dont let him move
        if (LorR != 0)
        {
            
            rb.AddForce(new Vector3((LorR * chaseSpeed) * Time.deltaTime, rb.velocity.y, rb.velocity.z), ForceMode.Impulse);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep();
        }

         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            health -= 1;
        }
        //setting of booleans for constraints
        if (other.gameObject.CompareTag("leftConstraint"))
        {
            leftstrained = true;
        }
        else if (other.gameObject.CompareTag("rightConstraint"))
        {
            rightstrained = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("leftConstraint"))
        {
            leftstrained = false;
        }
        else if (other.gameObject.CompareTag("rightConstraint"))
        {
            rightstrained = false;
        }
    }
    

    void OnCollisionEnter(Collision collision)
    {
        // Player runs into enemey freeze enemy postion
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // When no longer contacting the player, unfreeze the postition and continue to
        // chase the player
        rb.constraints = ~RigidbodyConstraints.FreezeAll;
        rb.constraints = RigidbodyConstraints.FreezeRotation ^ RigidbodyConstraints.FreezePositionY ^ RigidbodyConstraints.FreezePositionZ;
     
    }
}
