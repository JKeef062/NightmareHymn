using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script handles the maintenance of the Player's health bar
// within the game HUD


public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    // This sets the player's health to maximum
        // NOTE: Called upon instantiation of a player object
    public void SetFullHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }


    // This function sets the healthbar to represent the player's current health
    public void UpdateHealth(int currHealth)
    {
        healthSlider.value = currHealth;
    }
}
