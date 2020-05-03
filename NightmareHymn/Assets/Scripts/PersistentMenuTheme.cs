using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script makes the menu theme persist across all menu pages.
    // NOTE: Will destroy the menu audio when loading into level heirarchy.

public class PersistentMenuTheme : MonoBehaviour
{

    public static int audioSourceCount = 0;     // Holds the number of audio object currently in memory
                                                // NOTE: Used to ensure singleton audio source across menu
                                                //       traversal.

    void Awake()
    {   
        // Ensure audio source singleton
        if (audioSourceCount >= 1)
        {
            Destroy(this.gameObject);
        }
        else if (audioSourceCount == 0)
        {
            audioSourceCount++;                     // A new audio source has been put into memory
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Number of audio sources has gone negative ERROR
            Debug.Log("Number of audio sources has reached invalid value of: " + audioSourceCount);
        }
    }

    // If game has loaded into the level heirarchy destory this audio source game object
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "JaredLv1_Alpha")
        {
            Destroy(this.gameObject);
            audioSourceCount--;
        }
    }
}
