using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController: MonoBehaviour
{
    // Start is called before the first frame update

    public int nPotionsMax { get; private set; }
    public int nPotionsActual { get; private set; }
    public int potionHealingAmount { get; private set; }

    private void Awake()
    {
        nPotionsMax = 1;
        nPotionsActual = nPotionsMax;
        potionHealingAmount = 10;
    }

    void fillPotions()
    {
        nPotionsActual = nPotionsMax;
        Debug.Log("Potions refilled!");
        Debug.Log("Now you have " + nPotionsActual + " life potions!"); 
    }
    void boostNPotions()
    {
        nPotionsMax++; 
    }

    void boostPotionStreght()
    {
        potionHealingAmount += 5; 
    }

    public bool usePotion()
    {
        if (nPotionsActual > 0)
        {
            nPotionsActual--;
            Debug.Log("Potion used, now you have " + nPotionsActual + " potion(s).");
            return true; 
        }
        Debug.Log("You don't have more potions"); 
        return false; 
    }
}
