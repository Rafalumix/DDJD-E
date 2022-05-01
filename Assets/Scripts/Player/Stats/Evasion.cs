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
        dodgeChance = level * 5;
        
    }   

    public override void levelUp(){
        base.levelUp();
        dodgeChance = level * 5;
        Debug.Log("Player's dodge chance is now " + dodgeChance + "%");
    }
    
    public int getDodgeChance(){return dodgeChance;}

    
}

