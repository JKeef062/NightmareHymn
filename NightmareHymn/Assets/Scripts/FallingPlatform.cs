using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool fall;
    int count;
    public int lifeSpan;

    public Rigidbody rb;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        count = 1;
        fall = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fall == true)
        {
            rb.useGravity = true;
       
            if(count % lifeSpan == 0)
            {
                Destroy(gameObject);
            }
            count++;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fall = true;
        }
    }
}
