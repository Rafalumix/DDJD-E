using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            gainXp(30);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            printStats();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            levelUp();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            takeDamage(30);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            calculateOutgoingDamage();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            takePotion();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            die();
        }
    }

    public void die()
    {
        PlayerStats.life.setDead(true);
        Debug.Log(transform.name + " died.");
        SceneManager.LoadScene(0);
    }

    public void gainXp(int amount)
    {
        if (amount >= PlayerStats.xpNeededToLvlUp)
        {
            do
            {
                amount -= PlayerStats.xpNeededToLvlUp;
                levelUp();
                if (amount == 0) return;
            } while (amount >= PlayerStats.xpNeededToLvlUp);

        }
        PlayerStats.xpNeededToLvlUp -= amount;
    }

    private void levelUp()
    {
        Debug.Log(transform.name + " level up!");
        PlayerStats.level++;
        PlayerStats.life.levelUp();
        PlayerStats.endurance.levelUp();
        PlayerStats.vigor.levelUp();
        PlayerStats.evasion.levelUp();
        PlayerStats.luck.levelUp();
        PlayerStats.speed.levelUp();
        PlayerStats.xpNeededToLvlUp = PlayerStats.level * 10;
    }


    private void takeDamage(int enemyFlatDamage)
    {
        if (chanceHit(PlayerStats.evasion.getDodgeChance()))
        {
            Debug.Log("The player dodged an attack");
            return;
        }
        else
        {
            bool isDefending = false; //TODO NEED TO OBTAIN
            PlayerStats.life.removeHealth(PlayerStats.endurance.endureDamage(enemyFlatDamage, isDefending));
            if (PlayerStats.life.getDead())
            {
                die();
            }

        }
    }

    private int calculateOutgoingDamage()
    {
        bool crit = false;
        if (chanceHit(PlayerStats.luck.getCrit()))
        {
            crit = true;
        }
        int damage = PlayerStats.vigor.getFlatDamage();
        if (crit)
        {
            damage *= 2;
        }
        Debug.Log("The player will deal " + damage + " damage.");
        return damage;
    }

    private void printStats()
    {
        Debug.Log(PlayerStats.name + " " + ConvertToRoman.ToRoman(PlayerStats.numberOfGenerations) + " statistics:" + " Level: " + PlayerStats.level.ToString());
        Debug.Log("xp needed to level up: " + PlayerStats.xpNeededToLvlUp.ToString() + "; Number of potions: " + PlayerStats.nPotionsActual.ToString());
        Debug.Log("Life Points: " + PlayerStats.life.getHealth().ToString() + "/" + PlayerStats.life.getMaxHealth().ToString());
        for (int i = 0; i != PlayerStats.stats.Length; i++)
        {
            PlayerStats.stats[i].showDetails();
        }
    }

    private void takePotion()
    {
        if (PlayerStats.nPotionsActual > 0)
        {
            PlayerStats.nPotionsActual--;
            Debug.Log("Potion used, now you have " + PlayerStats.nPotionsActual + " potion(s).");
            PlayerStats.life.heal(PlayerStats.potionHealingAmount);
            Debug.Log(transform.name + " now have " + PlayerStats.life.getHealth() + " life points.");
        }
        else
        {
            Debug.Log("You don't have more potions");
        }
    }

    private bool chanceHit(int chance)
    {
        if (chance >= Random.Range(1, 101))
        {
            return true;
        }
        return false;
    }
}
