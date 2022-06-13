using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private string name;
    //Family 
    private int numberOfGenerations;
    private int actualRoomNumber;
    private string actualRoomID; 
    private int lastNoteRead; 

    //Potions
    private int nPotionsMax;
    private int nPotionsActual;
    private int potionHealingAmount;

    //Stats
    private int xpNeededToLvlUp;
    private int level;

    //Life 
    private int maxHealth; 
    private int currentHealth;

    //Endurance 
    private int armor;
    private float defensiveReduction;

    //Evasion
    private int dodgeChange;

    //Luck 
    private int critChange;

    //Speed 
    private float speedMultipier;

    //Vigor 
    private int flatDamage; 

    public PlayerData()
    {
        name = PlayerStats.name;
        numberOfGenerations = PlayerStats.numberOfGenerations;
        actualRoomNumber = PlayerStats.actualRoomNumber;
        actualRoomID = PlayerStats.actualRoomID; 
        lastNoteRead = PlayerStats.lastNoteRead; 
        nPotionsMax = PlayerStats.nPotionsMax;
        nPotionsActual = PlayerStats.nPotionsActual; 
        potionHealingAmount = PlayerStats.potionHealingAmount;
        xpNeededToLvlUp = PlayerStats.xpNeededToLvlUp;
        level = PlayerStats.level;
        maxHealth = PlayerStats.life.getMaxHealth();
        currentHealth = PlayerStats.life.getHealth();
        armor = PlayerStats.endurance.getArmor();
        defensiveReduction = PlayerStats.endurance.getReduction();
        dodgeChange = PlayerStats.evasion.getDodgeChance();
        critChange = PlayerStats.luck.getCrit();
        speedMultipier = PlayerStats.speed.getMoveSpeedMultiplier();
        flatDamage = PlayerStats.vigor.getFlatDamage(); 
    }

    public void LoadSavedDataInGame()
    {
        PlayerStats.name = name;
        PlayerStats.numberOfGenerations = numberOfGenerations;
        PlayerStats.actualRoomNumber = actualRoomNumber;
        PlayerStats.actualRoomID = actualRoomID; 
        PlayerStats.lastNoteRead = lastNoteRead; 
        PlayerStats.nPotionsMax = nPotionsMax; 
        PlayerStats.nPotionsActual = nPotionsActual;
        PlayerStats.potionHealingAmount = potionHealingAmount;
        PlayerStats.xpNeededToLvlUp = xpNeededToLvlUp;
        PlayerStats.level = level;
        PlayerStats.life.setMaxHealth(maxHealth);
        PlayerStats.life.setHealth(currentHealth);
        PlayerStats.endurance.setArmor(armor);
        PlayerStats.endurance.setReduction(defensiveReduction);
        PlayerStats.evasion.setDodgeChance(dodgeChange);
        PlayerStats.luck.setCrit(critChange);
        PlayerStats.speed.setMoveSpeedMultiplier(speedMultipier);
        PlayerStats.vigor.setFlatDamage(flatDamage);
    }

    

}
