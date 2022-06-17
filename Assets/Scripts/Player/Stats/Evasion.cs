using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Evasion : Stat
{
    private int dodgeChance; 
    public Evasion(int start_level){
        name = "Evasion";
        level = start_level;
        updateStat();
        
    }   

    public override void updateStat(){
        dodgeChance = level * 3;
    }

    public override void levelUp(int n=1){
        base.levelUp(n);
        updateStat();
        Debug.Log("Player's dodge chance is now " + dodgeChance + "%");
    }
    
    public int getDodgeChance(){return dodgeChance;}
    public void setDodgeChance(int value) { dodgeChance = value; }

    
}

