using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorController : Interactable
{
    [SerializeField] private int destinationSceneIndex;

    private int numberOfPowerUp; 

    private Sounds _sound = null;

    private void Awake()
    {
        numberOfPowerUp = RoomPowerups.getRandomBoost(); 

        _sound = GameObject.Find("Music").GetComponent<Sounds>(); 
    }
    override protected void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (SceneManager.GetActiveScene().name != GetSceneName.firstRoom)
        {
            Debug.Log(RoomPowerups.getName(numberOfPowerUp));
        } 
    }
    override protected void doActionOnClick()
    {
        Debug.Log("You touched " + gameObject.name);
        PlayerStats.actualRoomNumber++; 
        SceneManager.LoadScene(destinationSceneIndex); 
        if(_sound != null)
        {
            _sound.openDoorSound(); 
        }
        if(SceneManager.GetActiveScene().name != GetSceneName.firstRoom)
        {
            RoomPowerups.applyPowerUp(numberOfPowerUp); 
        }
    }
}
