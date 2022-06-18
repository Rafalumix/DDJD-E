using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenuScript : MonoBehaviour
{
    private GamePaused gamePaused = null; 

    [SerializeField] private GameObject PowerUpPopup = null;
    [SerializeField] private GameObject UI = null;
    UIScript UIscript = null; 

    Sounds _sounds = null; 

    private bool isPopupOpen = false; 
    private void Awake()
    {
        UIscript = UI.GetComponent<UIScript>();

        gamePaused = GetComponent<GamePaused>();
        _sounds = GameObject.Find("Music").GetComponent<Sounds>(); 
    }
    public void openPowerUpMenu()
    {
        StartCoroutine(openMenu());
    }
    public void closePowerUpMenu()
    {
        UIscript.updateHealthBarValue(); 
        UIscript.updatePotionValue(); 

        UI.SetActive(true);
        PowerUpPopup.SetActive(false);

        isPopupOpen = false;
        gamePaused.changePause();
    }
    public bool isPowerupPopupOpen()
    {
        return isPopupOpen; 
    }

    private IEnumerator openMenu()
    {
        yield return new WaitForSeconds(2);
        _sounds.roomCompletedSound(); 
        yield return new WaitForSeconds(2);

        UI.SetActive(false);
        PowerUpPopup.SetActive(true);

        isPopupOpen = true;
        gamePaused.changePause();
    }
}
