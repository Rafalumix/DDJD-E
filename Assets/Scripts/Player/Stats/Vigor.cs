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
        updateStat();
    }

    public override void updateStat(){
        flatDamage = 15 + (level-1)*4;
    }

    public override void levelUp(int n=1){
        base.levelUp();
        updateStat();
    }

    public int getFlatDamage(){ return flatDamage; }
    public void setFlatDamage(int value) { flatDamage = value; }
}

