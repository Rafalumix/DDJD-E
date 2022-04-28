using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorController : Interactable
{
    public int destinationSceneIndex; 
    override protected void doActionOnClick()
    {
        Debug.Log("You touched " + gameObject.name);
        SceneManager.LoadScene(destinationSceneIndex); 
    }
}
