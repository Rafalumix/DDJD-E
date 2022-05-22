using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    [SerializeField] private GameObject PopupWindow = null; 

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            PopupWindow.SetActive(true);
            Debug.Log("You went in the trigger zone.");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
            PopupWindow.SetActive(false);
            Debug.Log("You went out from the trigger zone."); 
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (triggerActive)
            {
                doActionOnClick(); 
            } else
            {
                Debug.Log("Not in range"); 
            }
        } 
    }

    virtual protected void doActionOnClick()
    {
        Debug.Log("You touched " + gameObject.name);
    }


}
