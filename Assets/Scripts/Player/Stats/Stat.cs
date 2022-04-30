using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Stat
{
    [SerializeField] //Can be modified inside the inspector 
    private int level = 1;

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
        return level; 
    }

    public void levelUpStat()
    {
        Debug.Log(name + " boosted!");
        level += 2; 
    }

    public void setStat(int n)
    {
        this.level = n; 
    }
}

