using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorController : Interactable
{
    [SerializeField] private int destinationSceneIndex;

    private Sounds sounds = null;

    private void Awake()
    {
        sounds = GameObject.Find("Music").GetComponent<Sounds>(); 
    }
    override protected void doActionOnClick()
    {
        Debug.Log("You touched " + gameObject.name);
        SceneManager.LoadScene(destinationSceneIndex); 
        if(sounds != null)
        {
            sounds.openDoorSound(); 
        }
    }
}
