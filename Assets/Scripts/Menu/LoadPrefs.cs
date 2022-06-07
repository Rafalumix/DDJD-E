using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class LoadPrefs : MonoBehaviour
{
    [Header("General Setting")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private MainMenuController menuController;

    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null; 

    [Header("Brightness Setting")]
    [SerializeField] private TMP_Text BrightnessTextValue = null;
    [SerializeField] private Slider BrightnessSlider = null;

    [Header("Quality Setting")]
    [SerializeField] public TMP_Dropdown qualityDropdown;

    [Header("Fullscreen Setting")]
    [SerializeField] private Toggle FullscreenToggle = null;

    [Header("Sensitivity Setting")]
    [SerializeField] private TMP_Text controllerSensTextValue = null;
    [SerializeField] private Slider controllerSensSlider = null;

    [Header("Invert Y Setting")]
    [SerializeField] private Toggle invertYToggle = null;
    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                menuController.reset("Audio"); 
            }

            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality); 
            }

            if (PlayerPrefs.HasKey("masterFullscreen")){
                int localFullscreen = PlayerPrefs.GetInt("masterFullscreen"); 
                
                if(localFullscreen == 1)
                {
                    Screen.fullScreen = true;
                    FullscreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    FullscreenToggle.isOn = false;
                }
            }

            if (PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                BrightnessTextValue.text = localBrightness.ToString("0.0");
                BrightnessSlider.value = localBrightness; 
                //Change the brightness
            }

            if (PlayerPrefs.HasKey("masterSen"))
            {
                float localSensitivity = PlayerPrefs.GetFloat("masterSen");

                controllerSensTextValue.text = localSensitivity.ToString("0");
                controllerSensSlider.value = localSensitivity;
                menuController.mainControllerSens = Mathf.RoundToInt(localSensitivity);
            }

            if (PlayerPrefs.HasKey("masterInvertY"))
            {
                if(PlayerPrefs.GetInt("masterInvertY") == 1)
                {
                    invertYToggle.isOn = true; 
                    //invert the Y
                } else
                {
                    invertYToggle.isOn = false; 
                }
            }
        }
    }
}
