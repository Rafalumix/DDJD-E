using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Stat
{
    [SerializeField] //Can be modified inside the inspector 
    private int baseValue = 1;
    private int modifier = 0;

    private string name;     
    public Stat(string name)
    {
        this.name = name; 
    }

    public string getName()
    {
        return name; 
    }

    public int getValue(){
        return baseValue+modifier; 
    }

    public void levelUpStat()
    {
        modifier += 1; 
    }
}

