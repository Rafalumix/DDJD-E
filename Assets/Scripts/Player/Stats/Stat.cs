using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Fields inside this class will show up in the inspector 
public abstract class Stat
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

    public virtual void levelUp(int n=1)
    {
        Debug.Log(name + " boosted!");
        level += n; 
    }

    public virtual void showDetails(){
        Debug.Log(name + " is level "+ level);
    }

    public abstract void updateStat();

    public void setStat(int n){
        level=n;
        updateStat();
    }

}

