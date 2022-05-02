using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static string name = "Bob";
    //Family 
    public static int numberOfGenerations = 1;     
    
    //Potions
    public static int nPotionsMax = 1;
    public static int nPotionsActual = nPotionsMax;
    public static int potionHealingAmount = 10;

    //Stats
    public static int xpNeededToLvlUp = 10;
    public static int level = 1;

    public static Life life = new Life(1);
    public static Endurance endurance = new Endurance(1);
    public static Vigor vigor = new Vigor(1);
    public static Evasion evasion = new Evasion(1);
    public static Luck luck = new Luck(1);
    public static Speed speed = new Speed(1);
    

    public static Stat[] stats =
    {
        PlayerStats.life, PlayerStats.endurance, PlayerStats.vigor, 
        PlayerStats.evasion, PlayerStats.luck, PlayerStats.speed
    }; 
}
