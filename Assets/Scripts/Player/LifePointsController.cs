using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LifePointsController : MonoBehaviour
{
    private PotionController potionController;
    
    // Start is called before the first frame update
    private void Awake()
    {
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
                PlayerStats.currentHealth += PlayerStats.potionHealingAmount;
                if (PlayerStats.currentHealth > PlayerStats.maxHealth)
                {
                    PlayerStats.currentHealth = PlayerStats.maxHealth; 
                }
                Debug.Log(transform.name + " now have " + PlayerStats.currentHealth + " life points.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            die(); 
        }
    }

    public void takeDamage(int damage)
    {
        //endurance effect 
        damage -= PlayerStats.endurance.getValue();
        damage = Mathf.Clamp(damage, 5, int.MaxValue);  //Minimum amount of damage taken is 5 


        PlayerStats.currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        Debug.Log(transform.name + " now have " + PlayerStats.currentHealth + " life points.");

        if (PlayerStats.currentHealth <= 0)
        {
            die(); 
        }
    }

    public void die()
    {
        PlayerStats.isDead = true;
        Debug.Log(transform.name + " died.");
        SceneManager.LoadScene(0);
    }
}
