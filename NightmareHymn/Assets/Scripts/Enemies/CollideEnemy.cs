using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideEnemy : BaseEnemy
{
    private Transform playerTransform;
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
    }

    void Update()
    {
        
    }
}
