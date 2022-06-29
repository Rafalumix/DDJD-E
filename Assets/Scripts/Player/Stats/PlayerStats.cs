using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static string name = "Burhiua the Old";
    //Family 
    public static int numberOfGenerations = 1;
    public static int actualRoomNumber = 0;
    public static int lastNoteRead = 0;
    public static string actualRoomID = GetSceneName.firstRoom; 
    
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

    public static void newGame()
    {
        name = "Burhiua the Old";
        numberOfGenerations = 1;
        actualRoomNumber = 0;
        actualRoomID = GetSceneName.firstRoom; 

        //Potions
        nPotionsMax = 2;
        refillPotions();
        potionHealingAmount = 10;

        //Stats
        xpNeededToLvlUp = 10;
        level = 1;

        life.setStat(1);
        endurance.setStat(1);
        vigor.setStat(1);
        evasion.setStat(1);
        luck.setStat(1);
        speed.setStat(1);
}
    //NEW HEIR GENERATOR FUNCTIONS
    public static void generateNewHeir()
    {
        PlayerStats.numberOfGenerations++;
        PlayerStats.actualRoomNumber = 0;
        actualRoomID = GetSceneName.firstRoom;
        PlayerStats.name = RandomNameGenerator.getRandomName(); 
        PlayerStats.life.fullHeal();
        refillPotions(); 

        generateNewStats();
        evaluateLevel();

        PlayerStats.life.setDead(false);
    }
    public static void levelUp()
    {
        PlayerStats.level++;
        PlayerStats.life.levelUp();
        PlayerStats.endurance.levelUp();
        PlayerStats.vigor.levelUp();
        PlayerStats.evasion.levelUp();
        PlayerStats.luck.levelUp();
        PlayerStats.speed.levelUp();
        PlayerStats.xpNeededToLvlUp = PlayerStats.level * 10;
    }
    public static void generateNewStats()
    {
        int points = 0;

        for (int i = 0; i != PlayerStats.stats.Length; i++)
        {
            points += (PlayerStats.stats[i].getValue() - 1) / 3;
            PlayerStats.stats[i].setStat((PlayerStats.stats[i].getValue() / 4) + 1);
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
        PlayerStats.level = ((temp) / 4) + 1;
    }
    public static void refillPotions()
    {
        PlayerStats.nPotionsActual = PlayerStats.nPotionsMax; 
    }
}
