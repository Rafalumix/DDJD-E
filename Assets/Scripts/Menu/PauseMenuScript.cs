using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;
using Cinemachine;

public class PauseMenuScript : MonoBehaviour
{
    private GamePaused gamePaused = null;

    [SerializeField] private GameObject PauseMenu = null;
    [SerializeField] private GameObject backToMainMenuPopup = null;
    private PowerUpMenuScript powerUpMenuScript = null; 
    private bool isPaused = false;

    [SerializeField] private GameObject UI = null;


    [Space(10)]

    [SerializeField] private TMP_Text nameLabel = null;
    [SerializeField] private TMP_Text levelLabel = null;
    [SerializeField] private TMP_Text roomCounter = null;
    [Header("Stats")]
    [SerializeField] private TMP_Text lifeLabel = null;
    [SerializeField] private TMP_Text enduranceLabel = null;
    [SerializeField] private TMP_Text vigorLabel = null;
    [SerializeField] private TMP_Text evasionLabel = null;
    [SerializeField] private TMP_Text luckLabel = null;
    [SerializeField] private TMP_Text speedLabel = null;
    private void Awake()
    {
        // We are in the game so the mouse is not visible 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        powerUpMenuScript = GetComponent<PowerUpMenuScript>();
        gamePaused = GetComponent<GamePaused>();
        if(PlayerStats.actualRoomNumber <= 12)
        {
            roomCounter.text = PlayerStats.actualRoomNumber + "/12";
        } else
        {
            roomCounter.text = "Boss";
        }
        updateStats(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !powerUpMenuScript.isPowerupPopupOpen() && !isPaused)
        {
            gamePaused.changePause();
            isPaused = !isPaused;
            if (isPaused)
            {
                openPauseMenu();
            }
            else
            {
                closePauseMenu();
            }
        }
    }
    void updateStats()
    {
        nameLabel.text = PlayerStats.name;
        levelLabel.text = "Lvl: " + PlayerStats.level.ToString();

        lifeLabel.text = PlayerStats.life.getValue().ToString("00");
        enduranceLabel.text = PlayerStats.endurance.getValue().ToString("00");
        vigorLabel.text = PlayerStats.vigor.getValue().ToString("00");
        evasionLabel.text = PlayerStats.evasion.getValue().ToString("00");
        luckLabel.text = PlayerStats.luck.getValue().ToString("00");
        speedLabel.text = PlayerStats.speed.getValue().ToString("00");
    }

    void openPauseMenu()
    {
        UI.SetActive(false);
        updateStats();

        PauseMenu.SetActive(true);
        isPaused = true; 
    }
    public void closePauseMenu()
    {
        UI.SetActive(true);

        PauseMenu.SetActive(false);
        backToMainMenuPopup.SetActive(false); 
        isPaused = false;
        gamePaused.changePause();
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene(GetSceneName.mainMenu);
    }
    public bool isGamePaused()
    {
        return isPaused; 
    }
}
