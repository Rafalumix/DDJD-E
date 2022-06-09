using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorController : Interactable
{
    [SerializeField] private int destinationSceneIndex;

    private Sounds _sound = null;

    private void Awake()
    {
        _sound = GameObject.Find("Music").GetComponent<Sounds>(); 
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
    }
}
