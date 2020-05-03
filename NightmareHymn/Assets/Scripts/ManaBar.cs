using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script handles the maintenance of the Player's mana bar
// within the game HUD

public class ManaBar : MonoBehaviour
{
    public Slider manaSlider;

    // This function sets the mana bar to represent the player's current mana
        // NOTE: Though the player may collect more mana tokens the bar has a 
        //       maximum of two to represent. Therefore, the player may collect
        //       as many as they wish but will only be able to use 2 and they do not roll over.
    public void UpdateMana()
    {
        manaSlider.value = PlayerController.mana;
    }
}
