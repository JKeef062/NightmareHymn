using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingTurretEnemy : BaseEnemy
{
    public float SafetyDistance;
    private Transform playerTransform;
    private float distance;
    public Rigidbody rb;

    public int fireRate;
    private int fireCount;

    private Vector3 offset;

        
    public GameObject baseBullet;   // Reference to base bullet prefab

    private 

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        speed = 2;
        playerTransform = player.GetComponent<Transform>();
        fireCount = 0;

        offset = new Vector3(transform.position.x , transform.position.y + 1, transform.position.z);

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Ensure player object exists
        if (playerTransform != null)
        {
            distance = Vector3.Distance(playerTransform.position, transform.position);
            transform.LookAt(playerTransform);

            //moving towards player
            if (distance > SafetyDistance)
            {
                fireCount = 0;
                //Debug.Log("Player is too far away MOVE NOW");
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            }
            else
            {
                //Debug.Log("SHOOT distance");
                if (fireCount % fireRate == 0)
                {
                    Shoot();
                }
                fireCount++;
            }
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
    }

    private void OnTriggerEnter(Collider other)
    {
        // Handle enemy hit with base bullet
        if (other.gameObject.CompareTag("bullet"))
        {
            health -= 1;
        }

        // Handle enemy hit with lava canon
        if (other.gameObject.CompareTag("LavaCanon"))
        {
            health -= 20;
        }
    }

    void Shoot()
    {
        Instantiate(baseBullet, transform.position + (playerTransform.position - transform.position).normalized ,Quaternion.LookRotation(playerTransform.position - transform.position));
    }
}