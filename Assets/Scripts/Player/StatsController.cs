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
        if (Input.GetKeyDown(KeyCode.I))
        {
            printStats(); 
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

    private void printStats()
    {
        Debug.Log(PlayerStats.name + "'s statistics:" + " Level: " + PlayerStats.level.ToString());
        Debug.Log("xp: " + PlayerStats.xp.ToString() + "; Number of potions: " + PlayerStats.nPotionsActual.ToString());
        Debug.Log("Life Points: " + PlayerStats.currentHealth.ToString() + "/" + PlayerStats.maxHealth.ToString());
        for (int i = 0; i!=PlayerStats.stats.Length; i++)
        {
            Debug.Log(PlayerStats.stats[i].getName() + ": " + PlayerStats.stats[i].getValue().ToString());
        }
    }
}
