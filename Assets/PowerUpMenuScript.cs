using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenuScript : MonoBehaviour
{
    private GamePaused gamePaused = null; 

    [SerializeField] private GameObject PowerUpPopup = null;
    [SerializeField] private GameObject UI = null;

    private bool isPopupOpen = false; 
    private void Awake()
    {
        gamePaused = GetComponent<GamePaused>(); 
    }
    public void openPowerUpMenu()
    {
        UI.SetActive(false);
        PowerUpPopup.SetActive(true);

        isPopupOpen = true;
        gamePaused.changePause();
    }
    public void closePowerUpMenu()
    {
        UI.SetActive(true);
        PowerUpPopup.SetActive(false);

        isPopupOpen = false;
        gamePaused.changePause();
    }
    public bool isPowerupPopupOpen()
    {
        return isPopupOpen; 
    }
}
