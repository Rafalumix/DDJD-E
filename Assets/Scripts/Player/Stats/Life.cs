using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Life : Stat
{
    private int maxHealth; 
    private int currentHealth;
    private bool isDead = false;
    public Life(int start_level){
        name = "Life";        
        level = start_level;
        updateStat();
        currentHealth = maxHealth;
    }

    public override void updateStat(){
        maxHealth = 100 + (level-1)*5;
    }

    public override void levelUp(int n=1){
        base.levelUp(n);
        updateStat();
        Debug.Log("Player's max health is now " + maxHealth);
    }

    public void fullHeal(){
        currentHealth = maxHealth;
    }

    public void heal(int amount){
        currentHealth = Mathf.Min(maxHealth,currentHealth+amount);
    }

    public void setDead(bool state){
        isDead=state;
    }

    public bool getDead(){ return isDead; }

    public int getHealth(){ return currentHealth; }
    public void setHealth(int value) { currentHealth = value; }

    public int getMaxHealth(){ return maxHealth; }
    public void setMaxHealth(int value) { maxHealth = value; }

    public void removeHealth(int damage){
        currentHealth = Mathf.Max(0,currentHealth-damage);
        if(currentHealth <= 0) { isDead = true;  }
    }

    public float getPercentageofHealth()
    {
        return (float)currentHealth / (float)maxHealth;
    }
    

    
}

