using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UIScript : MonoBehaviour
{
    [SerializeField] private Slider healthBar = null;
    [SerializeField] private TMP_Text PotionText = null;

    [SerializeField] private GameObject DamagePopup = null;
    [SerializeField] private GameObject HealingPopup = null;

    Color colorDamage;
    Color colorHealing;



    private void Start()
    {
        updateHealthBarValue();
        updatePotionValue();

        colorDamage = DamagePopup.GetComponent<Image>().color;
        colorHealing = HealingPopup.GetComponent<Image>().color;
    }
    private void Update()
    {
        if(DamagePopup.GetComponent<Image>().color.a > 0)
        {
            var color = DamagePopup.GetComponent<Image>().color;
            color.a -= 0.01f; 
            DamagePopup.GetComponent<Image>().color = color; 
        }
        if (HealingPopup.GetComponent<Image>().color.a > 0)
        {
            var color = HealingPopup.GetComponent<Image>().color;
            color.a -= 0.01f;
            HealingPopup.GetComponent<Image>().color = color;
        }
    }

    public void updateHealthBarValue()
    {
        healthBar.value = PlayerStats.life.getPercentageofHealth();
    }
    public void updatePotionValue()
    {
        PotionText.text = "x" + PlayerStats.nPotionsActual;
    }
    public void gotHurt()
    {
        colorDamage.a = 0.8f;

        DamagePopup.GetComponent<Image>().color = colorDamage; 
    }
    public void gotHealed()
    {
        colorHealing.a = 1f;

        HealingPopup.GetComponent<Image>().color = colorHealing;
    }

}
