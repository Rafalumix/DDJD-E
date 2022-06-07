using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Vigor : Stat
{
    private int flatDamage;
    public Vigor(int start_level){
        name = "Vigor";
        level = start_level;
        flatDamage = 20 + (level-1)*10;
        
    }

    public override void levelUp(){
        base.levelUp();
        flatDamage = 20 + (level-1)*10;
    }

    public int getFlatDamage(){ return flatDamage; }
    public void setFlatDamage(int value) { flatDamage = value; }
}

