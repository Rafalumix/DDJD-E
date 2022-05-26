using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UIScript : MonoBehaviour
{
    [SerializeField] private Slider healthBar = null;
    [SerializeField] private TMP_Text PotionText = null;

    private void Start()
    {
        updateHealthBarValue();
        updatePotionValue(); 
    }

    public void updateHealthBarValue()
    {
        healthBar.value = PlayerStats.life.getPercentageofHealth();
    }

    public void updatePotionValue()
    {
        PotionText.text = "x" + PlayerStats.nPotionsActual;
    }

}
