using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class RoomManager : MonoBehaviour
{
    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    private int numberOfEnemies = 0; 
    void Start()
    {
        Debug.Log("Actual room: " + PlayerStats.actualRoomNumber);
        PlayerStats.actualRoomID = SceneManager.GetActiveScene().name; 
        SaveSystem.SavePlayer();
        StartCoroutine(ConfirmationBox());
        numberOfEnemies += GameObject.FindGameObjectsWithTag("enemy").Length; 
    }
    public void reduceEnemies()
    {
        numberOfEnemies--;
        Debug.Log("Actual number of enemies in the room: " + numberOfEnemies);
    }
    public bool canGoInTheNextRoom()
    {
        if (numberOfEnemies <= 0)
        {
            return true; 
        } else
        {
            return false; 
        }
    }
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
