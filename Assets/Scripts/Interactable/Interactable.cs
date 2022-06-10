using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    [SerializeField] private bool isActivated = false;
    [SerializeField] private GameObject PopupWindow = null; 


    virtual protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            PopupWindow.SetActive(true);
            Debug.Log("You went in the trigger zone.");
        }
    }

    virtual protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = false; 
            triggerActive = false;
            PopupWindow.SetActive(false);
            Debug.Log("You went out from the trigger zone."); 
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (triggerActive && !isActivated)
            {
                isActivated = true; 
                doActionOnClick(); 
            } else if (triggerActive && isActivated)
            {
                isActivated = false;
                stopActionOnClick(); 
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

    virtual protected void stopActionOnClick()
    {
        Debug.Log("You finished touching " + gameObject.name);
    }


}
