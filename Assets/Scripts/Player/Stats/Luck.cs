using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Luck : Stat
{
    private int critChance; 
    public Luck(int start_level){
        name = "Luck";
        level = start_level;
        critChance = level * 5;
    }

    public override void levelUp(){
        base.levelUp();
        critChance = level * 5;
        Debug.Log("Player's crit chance is now " + critChance + "%");
    }

    public int getCrit(){ return critChance;}
    

    
}

