using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile_Handler : MonoBehaviour
{


    public float speed;
    public Rigidbody RBbullet;
    public float damage;


    // Start is called before the first frame update
    void Start()
    {
        RBbullet = GetComponent<Rigidbody>();
        RBbullet.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider info)
    {
        Debug.Log("Bullet hit a: " + info.tag);
        Destroy(gameObject);
    }

    public float getDamage()
    {
        return damage;
    }
    
}
