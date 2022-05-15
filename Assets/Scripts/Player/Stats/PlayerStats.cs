using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static string name = RandomNameGenerator.getRandomName();
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

    //NEW HEIR GENERATOR FUNCTIONS
    public static void generateNewHeir()
    {
        PlayerStats.numberOfGenerations++;
        PlayerStats.name = RandomNameGenerator.getRandomName(); 
        PlayerStats.life.fullHeal();
        PlayerStats.nPotionsActual = PlayerStats.nPotionsMax;

        generateNewStats();
        evaluateLevel();

        PlayerStats.life.setDead(false);
    }

    public static void generateNewStats()
    {
        int points = 0;

        for (int i = 0; i != PlayerStats.stats.Length; i++)
        {
            points += (PlayerStats.stats[i].getValue() - 1) / 3;
            PlayerStats.stats[i].setStat((PlayerStats.stats[i].getValue() / 3) + 1);
        }

        while (points != 0)  //assign randomly the following points 
        {
            int i = (int)Random.Range(0f, PlayerStats.stats.Length);
            PlayerStats.stats[i].levelUp();
            points--;
        }
    }

    public static void evaluateLevel()
    {
        int temp = -6;
        for (int i = 0; i != PlayerStats.stats.Length; i++)
        {
            temp += PlayerStats.stats[i].getValue();
        }
        PlayerStats.level = (temp) / 4;
    }
}
