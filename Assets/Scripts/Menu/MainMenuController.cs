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

    [Header("Resolution Dropdowns")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private int defaultResolution; 

    [Header("Gameplay Settings")]
    [SerializeField] private TMP_Text controllerSensTextValue = null;
    [SerializeField] private Slider controllerSensSlider = null;
    [SerializeField] private int defaultSen = 4;
    public int mainControllerSens = 4;

    [Header("Graphics Settings")]
    [SerializeField] private TMP_Text BrightnessTextValue = null;
    [SerializeField] private Slider BrightnessSlider = null;
    [SerializeField] private float defaultBrightness = 1f;

    [Space(10)]
    [SerializeField] public TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle FullscreenToggle = null;


    private int _qualityLevel;
    private bool _isFullscreen;
    private float _brightnessLevel; 

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null; 

    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        /*
        //Volume inizialization
        if (PlayerPrefs.GetFloat("masterVolume") == null)
        {
            PlayerPrefs.SetFloat("masterVolume", 100f);
        }

        AudioListener.volume = PlayerPrefs.GetFloat("masterVolume"); 
        volumeSlider.value = AudioListener.volume;
        volumeTextValue.text = (AudioListener.volume * 100).ToString("0");

        //Gameplay inizialization
        if(PlayerPrefs.GetFloat("masterSen") == null)
        {
            PlayerPrefs.SetFloat("masterSen", 4f); 
        }
        controllerSensSlider.value = PlayerPrefs.GetFloat("masterSen");
        controllerSensTextValue.text = PlayerPrefs.GetFloat("masterSen").ToString("0");
        if (PlayerPrefs.GetInt("masterInvertY")==1)
        {
            invertYToggle.isOn = true; 
        } */

        //Graphics inizialization
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for(int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option); 

            if(!PlayerPrefs.HasKey("indexResolution"))
            {
                 if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                            {
                                defaultResolution = i; 
                                PlayerPrefs.SetInt("indexResolution", i); 
                            }
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("indexResolution"); ;
        resolutionDropdown.RefreshShownValue();

        /*
        if (PlayerPrefs.GetInt("masterFullscreen") == 1)
        {
            Screen.fullScreen = true;
            FullscreenToggle.isOn = true; 
        } else
        {
            Screen.fullScreen = false;
            FullscreenToggle.isOn = false;
        }
        qualityDropdown.value = QualitySettings.GetQualityLevel(); */
    }
    /*private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }*/
    public void restartLevel()
    {
        PlayerStats.newGame(); 
        Debug.Log("Restart level."); 
        SceneManager.LoadScene(GetSceneName.firstRoom); 
    }

    public void loadLevel()
    {
        if (SaveSystem.isGameSaved())
        {
            PlayerData data = SaveSystem.LoadData();
            data.LoadSavedDataInGame(); 
            SceneManager.LoadScene(PlayerStats.actualRoomID); 
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

    //Graphics methods 
    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        BrightnessTextValue.text = brightness.ToString("0.0"); 
    }
    public void SetFullScreen(bool isFullscreen)
    {
        _isFullscreen = isFullscreen; 
    }
    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex; 
    }
    public void setResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("indexResolution", resolutionIndex);
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); 
    }
    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);
        //Change your brightness with your post processing or whatever it is

        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);

        PlayerPrefs.SetInt("masterFullscreen", (_isFullscreen ? 1 : 0));
        Screen.fullScreen = _isFullscreen;

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
        else if (MenuType == "Graphics")
        {
            //Reset brightnes value
            BrightnessSlider.value = defaultBrightness;
            BrightnessTextValue.text = defaultBrightness.ToString("0.0");

            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            FullscreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply(); 
        }
    }
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
