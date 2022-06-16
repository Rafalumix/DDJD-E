using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorController : Interactable
{
    [SerializeField] private int destinationSceneIndex;
    [SerializeField] private GameObject relativePainting = null; 

    RoomManager roomManager;

    private int numberOfPowerUp; 

    private Sounds _sound = null;

    private void Awake()
    {
        numberOfPowerUp = RoomPowerups.getRandomBoost();
        roomManager = GameObject.Find("GameManager").GetComponent<RoomManager>();

        if (relativePainting != null)
        {
            string name = RoomPowerups.getTextureName(numberOfPowerUp);
            Material tex = (Material)Resources.Load(name, typeof(Material));
            relativePainting.GetComponent<Renderer>().material = tex; 
        }
        

        _sound = GameObject.Find("Music").GetComponent<Sounds>(); 
    }
    override protected void OnTriggerEnter(Collider other)
    {
        if (roomManager.canGoInTheNextRoom())
        {
            base.OnTriggerEnter(other);

            if (SceneManager.GetActiveScene().name != GetSceneName.firstRoom)
            {
                 Debug.Log(RoomPowerups.getName(numberOfPowerUp));
            } 
        }
        
    }
    override protected void doActionOnClick()
    {
        Debug.Log("You touched " + gameObject.name);

        if (roomManager.canGoInTheNextRoom())
        {
            PlayerStats.actualRoomNumber++;
            SceneManager.LoadScene(destinationSceneIndex);
            if (_sound != null)
            {
                _sound.openDoorSound();
            }
            if (SceneManager.GetActiveScene().name != GetSceneName.firstRoom)
            {
                RoomPowerups.applyPowerUp(numberOfPowerUp);
            }
        }
    }
}
