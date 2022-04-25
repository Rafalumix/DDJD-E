using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100; 
    public int currentHealth { get; private set; }
    public int xp { get; private set; } 
    public int level { get; private set; }

    public Stat endurance; 
    public Stat damage; 

    //Possible idea of stats: Stamina, dexterity (faster attacks and speed)

    void Awake()
    {
        currentHealth = maxHealth;
        xp = 0;
        level = 1; 
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.T))
        {
            takeDamage(10); 
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            gainXp(100);
        }
    }

    public void takeDamage (int damage){
        //endurance effect 
        damage -= endurance.getValue();
        damage = Mathf.Clamp(damage, 5, int.MaxValue);  //Minimum amount of damage taken is 5 


        currentHealth -= damage; 
        Debug.Log(transform.name + " takes " + damage + " damage."); 


        if (currentHealth<=0){
            Die(); 
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
    
    public void Die(){
        Debug.Log(transform.name + " died."); 
    }
}
