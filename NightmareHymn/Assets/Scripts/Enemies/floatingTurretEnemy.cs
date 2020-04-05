using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingTurretEnemy : BaseEnemy
{
    public float SafetyDistance;
    private Transform playerTransform;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        speed = 2;
        playerTransform = player.GetComponent<Transform>();
    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);

        Debug.Log(distance);
        //moving towards player
        if (distance > SafetyDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

        }

    }

    void OnCollisionEnter(Collision collision)
    {

  
    }
}