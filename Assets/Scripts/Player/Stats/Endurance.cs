using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Endurance : Stat
{
    private int armor;
    private float defensiveReduction;
    private int minimumAmountOfDamageTaken = 5; 
    
    public Endurance(int start_level){
        name = "Endurance";
        level = start_level;
        armor = (level-1)*5;
        defensiveReduction = 0.5f;
    }

    public override void levelUp()
    {
        base.levelUp();
        armor = (level-1)*5;
        defensiveReduction = ((int)(level/5) / 10) + 0.5f;
        Debug.Log("Player's defensive reduction is now " + defensiveReduction);
    }

    public int getArmor(){return armor;}

    public float getReduction(){return defensiveReduction;}

    public int endureDamage(int flatDamage, bool defending){
        int result = flatDamage - armor;
        if (defending){
            result=(int)(result*defensiveReduction);
        }
        result = Mathf.Clamp(result, minimumAmountOfDamageTaken, int.MaxValue);  //Minimum amount of damage taken is 5 
        Debug.Log("The player took "+result+" damage ");
        return result;
    }

    
    
}

