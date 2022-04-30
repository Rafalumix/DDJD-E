using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static string name = "Bob"; 

    //Health 
    public static int maxHealth = 100; 
    public static int currentHealth = maxHealth;
    public static bool isDead = false;

    //Potions
    public static int nPotionsMax = 1;
    public static int nPotionsActual = nPotionsMax;
    public static int potionHealingAmount = 10;

    //Stats
    public static int xp = 0;
    public static int level = 1;

    public static Stat life = new Stat("Life");
    public static Stat endurance = new Stat("Endurance");
    public static Stat vigor = new Stat("Vigor");
    public static Stat evasion = new Stat("Evasion");
    public static Stat luck = new Stat("Luck");
    public static Stat speed = new Stat("Speed");
    

    public static Stat[] stats =
    {
        PlayerStats.life, PlayerStats.endurance, PlayerStats.vigor, 
        PlayerStats.evasion, PlayerStats.luck, PlayerStats.speed
    }; 
}
