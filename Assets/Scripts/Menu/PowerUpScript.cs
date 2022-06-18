using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class PowerUpScript : MonoBehaviour
{
    [SerializeField] private GameObject Image = null;
    [SerializeField] private TMP_Text Title = null;

    private int numberOfPowerUp;


    private void Awake()
    {
        numberOfPowerUp = RoomPowerups.getRandomBoost();
        string name = RoomPowerups.getTextureName(numberOfPowerUp);
        Sprite tex = Resources.Load<Sprite>(name);
        Image.GetComponent<Image>().sprite = tex;
        Title.text = RoomPowerups.getName(numberOfPowerUp); 
    }
   
     public void applyPowerUp()
    {
        RoomPowerups.applyPowerUp(numberOfPowerUp);
    }
}
