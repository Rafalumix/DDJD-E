using UnityEngine;

public class StatsController : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Y))
        {
            for (int i = 0; i != 10; i++)
            {
                levelUp(); 
            }
        }
    }

    public void gainXp (int amount)
    {
        PlayerStats.xp += amount; 
        Debug.Log(transform.name + " gained " + amount + "xp!");
        if (PlayerStats.xp >= amountOfXpNecessaryToLevelUp())
        {
            PlayerStats.xp -= amountOfXpNecessaryToLevelUp();
            levelUp();
        }
    }

    private void levelUp()
    {
        Debug.Log(transform.name + " level up!");
        PlayerStats.level++;

        //Should evaluate how to manage level up (possible idea: choose 2 stats at random and boost them only)
        int a = (int)Random.Range(0f, PlayerStats.stats.Length);
        PlayerStats.stats[a].levelUpStat();

        a = (int)Random.Range(0f, PlayerStats.stats.Length);
        PlayerStats.stats[a].levelUpStat();
    }

    private int amountOfXpNecessaryToLevelUp()
    {
        return (1000 + (PlayerStats.level * 200)); 
    }

    private void printStats()
    {
        Debug.Log(PlayerStats.name + " " + ConvertToRoman.ToRoman(PlayerStats.numberOfGenerations) + "'s statistics:" + " Level: " + PlayerStats.level.ToString());
        Debug.Log("xp: " + PlayerStats.xp.ToString() + "; Number of potions: " + PlayerStats.nPotionsActual.ToString());
        Debug.Log("Life Points: " + PlayerStats.currentHealth.ToString() + "/" + PlayerStats.maxHealth.ToString());
        for (int i = 0; i!=PlayerStats.stats.Length; i++)
        {
            Debug.Log(PlayerStats.stats[i].getName() + ": " + PlayerStats.stats[i].getValue().ToString());
        }
    }
}
