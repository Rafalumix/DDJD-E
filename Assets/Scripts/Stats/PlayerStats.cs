using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int xp { get; private set; } 
    public int level { get; private set; }

    public Stat endurance; 
    public Stat damage; 

    //Possible idea of stats: Stamina, dexterity (faster attacks and speed)

    void Awake()
    {
        xp = 0;
        level = 1; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            gainXp(100);
        }
    }

    public void gainXp (int amount)
    {
        xp += amount; 
        Debug.Log(transform.name + " gained " + amount + "xp!");
        if (xp >= 1000)
        {
            levelUp(); 
            xp -= 1000; 
        }
    }

    private void levelUp()
    {
        Debug.Log(transform.name + " level up!");
        level++; 
        endurance.levelUpStat();
        damage.levelUpStat(); 
    }
}
