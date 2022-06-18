using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Speed : Stat
{
    private float speedMultiplier; 
    public Speed(int start_level){
        name = "Speed";
        level = start_level;
        updateStat();
        
    }

    public override void updateStat(){
        speedMultiplier = (level-1)*5/100 + 1;
    }

    public override void levelUp(int n=1){
        base.levelUp(n);
        updateStat();
        Debug.Log("Player's speed multiplier is now " + speedMultiplier );
    }

    public float getMoveSpeedMultiplier() { return speedMultiplier; }
    public void setMoveSpeedMultiplier(float value) { speedMultiplier = value; }

    
}

