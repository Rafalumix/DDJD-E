using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro; 

public class MainMenuController : MonoBehaviour
{

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null; 

    [Header("Load Level")]
    [SerializeField] private GameObject noSavedGameDialog = null;
    private string levelToLoad;

    [Header("Gameplay Settings")]
    [SerializeField] private TMP_Text controllerSensTextValue = null;
    [SerializeField] private Slider controllerSensSlider = null;
    [SerializeField] private int defaultSen = 4;
    public int mainControllerSens = 4;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null; 

    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;


    private void Awake()
    {
        if (PlayerPrefs.GetFloat("masterVolume") == null)
        {
            PlayerPrefs.SetFloat("masterVolume", 100f);
        }

        AudioListener.volume = PlayerPrefs.GetFloat("masterVolume"); 
        volumeSlider.value = AudioListener.volume;
        volumeTextValue.text = (AudioListener.volume * 100).ToString("0");

        if(PlayerPrefs.GetFloat("masterSen") == null)
        {
            PlayerPrefs.SetFloat("masterSen", 4f); 
        }
        controllerSensSlider.value = PlayerPrefs.GetFloat("masterSen");
        controllerSensTextValue.text = PlayerPrefs.GetFloat("masterSen").ToString("0");
        if (PlayerPrefs.GetInt("masterInvertY")==1)
        {
            invertYToggle.isOn = true; 
        }
    }
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

    //Gameplay methods 
    public void SetControllerSensitivity(float sensitivity)
    {
        mainControllerSens = Mathf.RoundToInt(sensitivity);
        controllerSensTextValue.text = sensitivity.ToString("0"); 
    }
    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1); 
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0); 
        }

        PlayerPrefs.SetFloat("masterSen", mainControllerSens);
        StartCoroutine(ConfirmationBox()); 
    }

    public void reset(string MenuType)
    { 
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = (defaultVolume*100).ToString("0."); 
        }
        else if (MenuType == "Gameplay")
        {
            controllerSensTextValue.text = defaultSen.ToString();
            controllerSensSlider.value = defaultSen;
            mainControllerSens = defaultSen;
            invertYToggle.isOn = false;
            GameplayApply(); 
        }
    }
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
