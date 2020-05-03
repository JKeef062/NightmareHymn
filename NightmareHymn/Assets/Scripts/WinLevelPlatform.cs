using UnityEngine;

/*
 * This script defines how the player wins the level when
 * they reach the platform that this script is attached to.
 */

public class WinLevelPlatform : MonoBehaviour
{
    public GameManager theGM;

    private void OnTriggerEnter(Collider other)
    {
        theGM.WinLevel();
    }
}
