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

    public static Stat vitality = new Stat("vitality");
    public static Stat endurance = new Stat("endurance");
    public static Stat dexterity = new Stat("dexterity");
    public static Stat strength = new Stat("strength");
    public static Stat evasion = new Stat("evasion");
    public static Stat luck = new Stat("luck");

    public static Stat[] stats =
    {
        PlayerStats.vitality, PlayerStats.endurance, PlayerStats.dexterity, 
        PlayerStats.strength, PlayerStats.evasion, PlayerStats.luck
    }; 
}
