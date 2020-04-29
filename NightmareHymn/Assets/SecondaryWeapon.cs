using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script defines the behavior of the player's secondary weapon

public class SecondaryWeapon : MonoBehaviour
{
    private int lifeSpan = 30;        // This variables is used to control how long this explosion remains active in game (in frames)
    Vector3 size;                    // Holds the size of the explosion (updated every frame object is active)
    public float finalDiameter = 6;  // Holds the largest diameter the explosion will reach throughout its life

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check TTL and destory object is frame count has expired
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }

        // Decrement the lifespan
        lifeSpan--;

        // Animation (Rotating and growing in size)
        size = transform.localScale;
        AnimateExplosion();
    }

    void AnimateExplosion()
    {

        transform.Rotate(new Vector3(175f, 190f, -170f) * Time.deltaTime);
        
        // Restrict the final size of the explosion
        if (size.x < finalDiameter)
        {
            size.x += .5f;
            size.y += .5f;
            size.z += .5f;
        }
        
        transform.localScale = new Vector3(size.x, size.y, size.z);
    }
}
