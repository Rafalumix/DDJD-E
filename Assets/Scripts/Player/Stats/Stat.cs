using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public class Stat
{
    [SerializeField] //Can be modified inside the inspector 
    protected int level = 1;

    protected string name = "";

    public string getName()
    {
        return name; 
    }

    public int getValue(){
        return level; 
    }

    public virtual void levelUp()
    {
        Debug.Log(name + " boosted!");
        level += 1; 
    }

    public void setStat(int n)
    {
        this.level = n; 
    }
}

