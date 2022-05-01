using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    
    private PotionController potionController = new PotionController();
    
    // Start is called before the first frame update
    private void Awake()
    {
        potionController = GetComponent<PotionController>();
    }
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
            takeDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (potionController.usePotion())
            {
                PlayerStats.life.heal(PlayerStats.potionHealingAmount);
                Debug.Log(transform.name + " now have " + PlayerStats.life.getHealth() + " life points.");
            }
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

    public void gainXp (int amount)
    {
        //Change this
        if (amount>=PlayerStats.xpNeededToLvlUp){
            do{
                amount-=PlayerStats.xpNeededToLvlUp;
                levelUp();
                if(amount==0) return;
            }while(amount>=PlayerStats.xpNeededToLvlUp);
            
        }
        PlayerStats.xpNeededToLvlUp-=amount;
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


    private void takeDamage(int enemyFlatDamage){
        if ( chanceHit(PlayerStats.evasion.getDodgeChance())){
            Debug.Log("The player dodged and attack");
            return;
        }
        else
        {
            bool isDefending = false; //NEED TO OBTAIN
            PlayerStats.life.removeHealth(PlayerStats.endurance.endureDamage());
            if(PlayerStats.life.getDead()){
                die();
            }

        }


    }

    private int calculateOutgoingDamage(){
        
        return 1;
    }

    private void printStats()
    {
        // Debug.Log(PlayerStats.name + " " + ConvertToRoman.ToRoman(PlayerStats.numberOfGenerations) + "'s statistics:" + " Level: " + PlayerStats.level.ToString());
        // Debug.Log("xp: " + PlayerStats.xp.ToString() + "; Number of potions: " + PlayerStats.nPotionsActual.ToString());
        // Debug.Log("Life Points: " + PlayerStats.currentHealth.ToString() + "/" + PlayerStats.maxHealth.ToString());
        // for (int i = 0; i!=PlayerStats.stats.Length; i++)
        // {
        //     Debug.Log(PlayerStats.stats[i].getName() + ": " + PlayerStats.stats[i].getValue().ToString());
        // }
    }

    private bool chanceHit(int chance){
        if ( chance >= Random.Range(1, 101)){
            return true;
        }
        return false;
    }
}
