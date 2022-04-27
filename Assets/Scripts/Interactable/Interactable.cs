using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
            //Close the menu/interface
            Debug.Log("You went out from the trigger zone."); 
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (triggerActive)
            {
                Debug.Log("You touched " + gameObject.name); 
            } else
            {
                Debug.Log("Not in range"); 
            }
        } 
    }

}
