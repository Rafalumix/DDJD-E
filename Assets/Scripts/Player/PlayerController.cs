using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UIScript UIScript = null;
    [SerializeField] private GameObject LevelUpPopup = null; 

    private SoundCharacter _sound;
    private Animator _animator; 

    private void Awake()
    {
        _sound = GetComponent<SoundCharacter>();
        _animator = GetComponent<Animator>(); 
    }

    private void Update()
    {

        // Only from grading purposes. Ease traversing the game
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("KingRoom");
            PlayerStats.lastNoteRead = 12;
        }
        
        // Only from grading purposes. Ease traversing the game
        if (Input.GetKeyDown(KeyCode.Y))
        {
            levelUp();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            takePotion();
        }
    }

    public void die()
    {
        PlayerStats.life.setDead(true);
        Debug.Log(transform.name + " died.");
        SceneManager.LoadScene(1);
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
        StartCoroutine(ConfirmationBox());
        _sound.levelUpSound();
        PlayerStats.levelUp();
        UIScript.updateHealthBarValue(); 
    }
    public IEnumerator ConfirmationBox()
    {
        LevelUpPopup.SetActive(true);
        yield return new WaitForSeconds(2);
        LevelUpPopup.SetActive(false);
    }
    public void takeDamage(int enemyFlatDamage)
    {
        if (chanceHit(PlayerStats.evasion.getDodgeChance()))
        {
            _sound.dodgeSound(); 
            Debug.Log("The player dodged an attack");
            return;
        }
        else
        {
            CinemachineCameraShaker.instance.ShakeCamera(0.1f);
            UIScript.gotHurt(); 
            bool isDefending = _animator.GetBool("Block");
            if (isDefending)
            {
                _sound.blockSound(); 
            } else if (PlayerStats.life.getHealth() > 50)
            {
                _sound.getHitSound(); 
            } else
            {
                _sound.getCriticalHitSound(); 
            }
            changeLife(false, PlayerStats.endurance.endureDamage(enemyFlatDamage, isDefending)); 
            if (PlayerStats.life.getDead())
            {
                Debug.Log("I'm dead"); 
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
            UIScript.gotHealed(); 
            _sound.dringPotionSound(); 
            PlayerStats.nPotionsActual--;
            UIScript.updatePotionValue();
            Debug.Log("Potion used, now you have " + PlayerStats.nPotionsActual + " potion(s).");
            changeLife(true, PlayerStats.potionHealingAmount);            
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

    private void changeLife(bool isHealing, int amount)
    {
        if (isHealing)
        {
            PlayerStats.life.heal(amount);
        }
        else
        {
            PlayerStats.life.removeHealth(amount);
        }
        Debug.Log(transform.name + " now have " + PlayerStats.life.getHealth() + " life points.");
        UIScript.updateHealthBarValue();
    }
}
