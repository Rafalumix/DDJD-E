using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Speed : Stat
{
    private int speedIncrease; 
    public Speed(int start_level){
        name = "Speed";
        level = start_level;
        speedIncrease = 0;
    }

    public override void levelUp(){
        base.levelUp();
        speedIncrease =  (level-1)*5;
        Debug.Log("Player'sspeedis now " + speedIncrease + "%");
    }
    

    
}

