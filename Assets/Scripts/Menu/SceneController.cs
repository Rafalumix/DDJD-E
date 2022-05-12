using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro; 

public class SceneController : MonoBehaviour
{

    [Header("Load Level")]
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private GameObject confirmationPrompt = null; 

    private void Update()
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

    public void loadLevel()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad); 
        } else
        {
            noSavedGameDialog.SetActive(true); 
        }
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(GetSceneName.mainMenu);
    }

    public void exit()
    {
        Application.Quit(); 
    }

    //Volume methods 
    public void setVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = (volume*100).ToString("0."); 
    }
    public void volumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox()); 
    }
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
