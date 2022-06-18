using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaused : MonoBehaviour
{
    private bool isPaused = false;
    void Update()
    {
        if (isPaused)
        {
            pauseGame();
        }
        else
        {
            unpauseGame();
        }
    }
    public void pauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = Mathf.Epsilon;
        AudioListener.pause = true;
        isPaused = true;
    }
    public void unpauseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;
        AudioListener.pause = false;
        isPaused = false;
    }
    public bool isPowerupPopupOpen()
    {
        return isPaused;
    }
    public void changePause()
    {
        isPaused = !isPaused; 
    }
}
