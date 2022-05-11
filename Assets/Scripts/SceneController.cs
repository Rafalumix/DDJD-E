using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneController : MonoBehaviour
{
    
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.R))
        {
            restartLevel(); 
        }
    }
    public void restartLevel()
    {
        generateNewHeir(); 
        Debug.Log("Restart level."); 
        SceneManager.LoadScene(1); 
    }

    public void generateNewHeir()
    {
        PlayerStats.numberOfGenerations++;
        PlayerStats.life.fullHeal();
        PlayerStats.nPotionsActual = PlayerStats.nPotionsMax;

        generateNewStats();
        evaluateLevel(); 

        PlayerStats.life.setDead(false); 
    }

    public void generateNewStats()
    {
        int points = 0;

        for (int i = 0; i != PlayerStats.stats.Length; i++)
        {
            points += (PlayerStats.stats[i].getValue() - 1) / 3;
            PlayerStats.stats[i].setStat((PlayerStats.stats[i].getValue() / 3) + 1);
        }

        while (points != 0)  //assign randomly the following points 
        {
            int i = (int)Random.Range(0f, PlayerStats.stats.Length);
            PlayerStats.stats[i].levelUp();
            points--; 
        }
    }

    public void evaluateLevel()
    {
        int temp = -6; 
        for (int i = 0; i != PlayerStats.stats.Length; i++)
        {
            temp += PlayerStats.stats[i].getValue();
        }
        PlayerStats.level = (temp)/4; 
    }

    public void returnToMenu()
    {
        Debug.Log("Back to main menu.");

    }
}
