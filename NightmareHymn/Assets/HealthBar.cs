using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void SetFullHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void UpdateHealth(int currHealth)
    {
        healthSlider.value = currHealth;
    }
}
