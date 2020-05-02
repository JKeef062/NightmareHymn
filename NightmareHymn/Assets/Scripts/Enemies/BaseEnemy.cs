using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float health;
    public float speed;
    private float startSpeed;
    public GameObject player;
    //public vector2 distfromTarget; possibly add later
    public GameObject weapon; //enemies weapon, allows changing of weapons

    public GameObject healthdrop;
    public GameObject manadrop;


    void Start()
    {
        startSpeed = speed;
    }
        


    // Update is called once per frame
    void Update()
    {
        if (isDead())
        {
            int chance = Random.Range(0, 2);
            if(chance == 0)
            {
                Instantiate(healthdrop,transform.position,transform.rotation);
            }
            else
            {
                //no need to create mana yet un comment when attack done
                Instantiate(manadrop,transform.position,transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player touched by enemy");
            speed = 0;
        }

    }

    void OnCollisionExit()
    {
        speed = startSpeed;
    }

    bool isDead()
    {
        if(this.health <= 0)
        {
            return true;
        }
        return false;
    }
}
