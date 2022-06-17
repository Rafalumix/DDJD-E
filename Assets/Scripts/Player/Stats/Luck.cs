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
        updateStat();
    }

    public override void updateStat(){
        critChance = level * 3;
    }

    public override void levelUp(int n=1){
        base.levelUp(n);
        updateStat();
        Debug.Log("Player's crit chance is now " + critChance + "%");
    }

    public int getCrit(){ return critChance; }
    public void setCrit(int value) { critChance = value; }
    

    
}

