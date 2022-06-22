using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RoomPowerups
{
    private static int valueOfBoost = 3;

    private static int[] actualPowerUp = {-1, -1, -1}; 

    private static string[] powerups = {"Increase potions",
    "Level up!",
    "Life up!",
    "Endurance up!",
    "Vigor up!",
    "Evasion up!",
    "Luck up!",
    "Speed up!",
    "Refill potions",
    "Potion Healing up!",
    };
    private static string[] textures = {"Icons/Potion_Number_Up_Icon",
    "Icons/Level_Up_Icon",
    "Icons/Life_Up_Icon",
    "Icons/Endurance_Up_Icon",
    "Icons/Vigor_Up_Icon",
    "Icons/Evasion_Up_Icon",
    "Icons/Luck_Up_Icon",
    "Icons/Speed_Up_Icon",
    "Icons/Refill_Potion_Icon",
    "Icons/Potion_Healing_Up",
    };
    public static void generateSetOfBoosts()
    {
        actualPowerUp[0] = (int)Random.Range(0f, powerups.Length);
        actualPowerUp[1] = (int)Random.Range(0f, powerups.Length);
        actualPowerUp[2] = (int)Random.Range(0f, powerups.Length);
        while (actualPowerUp[0] == actualPowerUp[1] || actualPowerUp[0] == actualPowerUp[2])
        {
            actualPowerUp[0] = (int)Random.Range(0f, powerups.Length);
        }
        while (actualPowerUp[1] == actualPowerUp[0] || actualPowerUp[1] == actualPowerUp[2])
        {
            actualPowerUp[1] = (int)Random.Range(0f, powerups.Length);
        }
        while (actualPowerUp[2] == actualPowerUp[0] || actualPowerUp[2] == actualPowerUp[1])
        {
            actualPowerUp[2] = (int)Random.Range(0f, powerups.Length);
        }
    }
    public static int getBoost(int n)
    {
        if (actualPowerUp[n] == -1)
        {
            generateSetOfBoosts(); 
        }
        return actualPowerUp[n];
    }
    public static string getName(int n)
    {
        return powerups[n]; 
    }
    public static string getTextureName(int n)
    {
        return textures[n]; 
    }
    public static void applyPowerUp(int n)
    {
        switch (n)
        {
            case 0:
                BoostPotions(); 
                break;
            case 1:
                LevelUp(); 
                break;
            case 2:
                LifeUp(); 
                break;
            case 3:
                EnduranceUp(); 
                break;
            case 4:
                VigorUp(); 
                break;
            case 5:
                EvasionUp(); 
                break;
            case 6:
                LuckUp(); 
                break;
            case 7:
                SpeedUp(); 
                break;
            case 8:
                RefillPotions(); 
                break;
            case 9:
                IncreasePotionHealing(); 
                break; 
        }
    }
    private static void BoostPotions()
    {
        Debug.Log(powerups[0]);
        PlayerStats.nPotionsMax++;
        PlayerStats.nPotionsActual++; 
    }
    private static void LevelUp()
    {
        Debug.Log(powerups[1]);
        PlayerStats.levelUp(); 
    }
    private static void LifeUp()
    {
        Debug.Log(powerups[2]);
        for (int i = 0; i != valueOfBoost; i++)
        {
            PlayerStats.life.levelUp(); 
        }
    }
    private static void EnduranceUp()
    {
        Debug.Log(powerups[3]);
        for (int i = 0; i != valueOfBoost; i++)
        {
            PlayerStats.endurance.levelUp();
        }
    }
    private static void VigorUp()
    {
        Debug.Log(powerups[4]);
        for (int i = 0; i != valueOfBoost; i++)
        {
            PlayerStats.vigor.levelUp();
        }
    }
    private static void EvasionUp()
    {
        Debug.Log(powerups[5]);
        for (int i = 0; i != valueOfBoost; i++)
        {
            PlayerStats.evasion.levelUp();
        }
    }
    private static void LuckUp()
    {
        Debug.Log(powerups[6]);
        for (int i = 0; i != valueOfBoost; i++)
        {
            PlayerStats.luck.levelUp();
        }
    }
    private static void SpeedUp()
    {
        Debug.Log(powerups[7]);
        for (int i = 0; i != valueOfBoost; i++)
        {
            PlayerStats.speed.levelUp();
        }
    }
    private static void RefillPotions()
    {
        Debug.Log(powerups[8]);
        PlayerStats.refillPotions(); 
    }
    private static void IncreasePotionHealing()
    {
        Debug.Log(powerups[9]);
        PlayerStats.potionHealingAmount += 10; 
    }
}
