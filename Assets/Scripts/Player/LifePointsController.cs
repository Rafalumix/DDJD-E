using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePointsController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public bool isDead { get; private set; }
    private PlayerStats playerStats;
    private PotionController potionController; 
    
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = maxHealth;
        isDead = false; 
        playerStats = GetComponent<PlayerStats>();
        potionController = GetComponent<PotionController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            takeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (potionController.usePotion())
            {
                currentHealth += potionController.potionHealingAmount;
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth; 
                }
                Debug.Log(transform.name + " now have " + currentHealth + " life points.");
            }
            
        }
    }

    public void takeDamage(int damage)
    {
        //endurance effect 
        damage -= playerStats.endurance.getValue();
        damage = Mathf.Clamp(damage, 5, int.MaxValue);  //Minimum amount of damage taken is 5 


        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        Debug.Log(transform.name + " now have " + currentHealth + " life points.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        isDead = true;
        Debug.Log(transform.name + " died.");
    }
}
