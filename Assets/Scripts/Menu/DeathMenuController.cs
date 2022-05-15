using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DeathMenuController : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void restartLevel()
    {
        PlayerStats.generateNewHeir();
        Debug.Log("Restart level.");
        SceneManager.LoadScene(GetSceneName.firstRoom);
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene(GetSceneName.mainMenu);
    }
}
