using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float health;
    public float speed;
    public GameObject player; 
    //public vector2 distfromTarget; possibly add later
    public GameObject weapon; //enemies weapon, allows changing of weapons
   


    // Update is called once per frame
    void Update()
    {
        if (isDead())
        {
            Destroy(gameObject);
        }

        Debug.Log(health);
    }

    void OnCollsionEnter(Collision other)
    {
        if(other.gameObject.tag == "bullet")
        {
            health -= 5;//other.gameObject.GetComponent<projectile_handler>().getDamage();
        }
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
