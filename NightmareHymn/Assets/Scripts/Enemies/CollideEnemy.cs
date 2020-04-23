using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideEnemy : BaseEnemy
{
    private Transform playerTransform;
    public Rigidbody rb;

    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        health = 5;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }
}
