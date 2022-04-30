using UnityEngine;

public class StatsController : MonoBehaviour
{

    void Awake()
    {
       
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
        PlayerStats.xp += amount; 
        Debug.Log(transform.name + " gained " + amount + "xp!");
        if (PlayerStats.xp >= 1000)
        {
            levelUp();
            PlayerStats.xp -= 1000; 
        }
    }

    private void levelUp()
    {
        Debug.Log(transform.name + " level up!");
        PlayerStats.level++;

        //Should evaluate how to manage level up (possible idea: choose 2 stats at random and boost them only)
        int a = (int)Random.Range(0f, 6f);
        PlayerStats.stats[a].levelUpStat();
        Debug.Log(PlayerStats.stats[a].getName() + " boosted!");

        a = (int)Random.Range(0f, 6f);
        PlayerStats.stats[a].levelUpStat();
        Debug.Log(PlayerStats.stats[a].getName() + " boosted!"); 
    }
}
