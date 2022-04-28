using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController: MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
       
    }

    void fillPotions()
    {
        PlayerStats.nPotionsActual = PlayerStats.nPotionsMax;
        Debug.Log("Potions refilled!");
        Debug.Log("Now you have " + PlayerStats.nPotionsActual + " life potions!"); 
    }
    void boostNPotions()
    {
        PlayerStats.nPotionsMax++; 
    }

    void boostPotionStreght()
    {
        PlayerStats.potionHealingAmount += 5; 
    }

    public bool usePotion()
    {
        if (PlayerStats.nPotionsActual > 0)
        {
            PlayerStats.nPotionsActual--;
            Debug.Log("Potion used, now you have " + PlayerStats.nPotionsActual + " potion(s).");
            return true; 
        }
        Debug.Log("You don't have more potions"); 
        return false; 
    }
}
