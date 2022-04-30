using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
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

    public static Stat life = new Stat("life");
    public static Stat endurance = new Stat("endurance");
    public static Stat vigor = new Stat("vigor");
    public static Stat evasion = new Stat("evasion");
    public static Stat speed = new Stat("speed");
    public static Stat luck = new Stat("luck");

    public static Stat[] stats =
    {
        PlayerStats.life, PlayerStats.endurance, PlayerStats.vigor, 
        PlayerStats.evasion, PlayerStats.speed, PlayerStats.luck
    }; 
}
