using UnityEngine;

public class Weapon : MonoBehaviour
{
    // ------------ REFERENCES/VARIABLES ------------
    public Transform firePoint;     // Location to fire bullets from
    public Transform playerLoc;     // Current player location
    public GameObject baseBullet;   // Reference to base bullet prefab
    float vertDirection;            // Holds a value representing the 
                                        //vertical axis on controller
    float horizDirection;           // Holds a value representing the 
                                        //vertical axis on controller

    // Update is called once per frame
    void Update()
    {
        vertDirection = Input.GetAxisRaw("Vertical");
        horizDirection = Input.GetAxisRaw("Horizontal");
        SetFirePoint(vertDirection, horizDirection);

        if (Input.GetButtonDown("Fire1"))
        {
            ShootBaseWeapon();
        }
    }

    // This funtion sets the firepoint based on the players orientation
    // and if they are holding up or not
    void SetFirePoint(float verticalAxis, float horizAxis)
    {
        // Limit player to shooting in cardinal directions
        if (verticalAxis > 0)
        {
            firePoint.position = new Vector3(playerLoc.position.x, playerLoc.position.y + 1f, playerLoc.position.z);
            firePoint.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (horizAxis < 0)
        {
            firePoint.position = new Vector3(playerLoc.position.x - 1f , playerLoc.position.y, playerLoc.position.z);
            firePoint.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            firePoint.position = new Vector3(playerLoc.position.x + 1f, playerLoc.position.y, playerLoc.position.z);
            firePoint.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // This function spawns a new base bullet to the game at the current
    // firePoint
    void ShootBaseWeapon()
    {
        Instantiate(baseBullet, firePoint.position, firePoint.rotation);
    }
}
