using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideEnemy : BaseEnemy
{
    private Transform playerTransform;
    public Rigidbody rb;
    private float LorR = 0;
    public float chaseSpeed = 100;

    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        health = 5;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        LorR = playerTransform.position.x - transform.position.x;
        
        if (LorR > 0)
        {
            LorR = 1f;
        }
        else if (LorR < 0)
        {
            LorR = -1f;
        }
        else
        {
            Debug.Log("Chasing Enemy: Left or Right set to 0");
        }

        //rb.velocity = new Vector3((LorR * chaseSpeed) * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        rb.AddForce(new Vector3((LorR * chaseSpeed) * Time.deltaTime, rb.velocity.y, rb.velocity.z), ForceMode.Impulse);
    }
}
