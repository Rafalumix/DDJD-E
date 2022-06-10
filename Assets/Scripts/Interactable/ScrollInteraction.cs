using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScrollInteraction : Interactable
{
    [SerializeField] GameObject PopupScroll = null;
    [SerializeField] TMP_Text Popuptitle = null;
    [SerializeField] TMP_Text Popuptext = null;

    private int n = 0; 
    private bool alreadyReadInThisRoom = false; 


    override protected void doActionOnClick()
    {
        base.doActionOnClick();
        if (!alreadyReadInThisRoom)
        {
            evaluateReadingPage(); 
        }
        
        string title = ScrollManager.readTitle(n);
        string text = ScrollManager.readText(n);
        Popuptitle.text = title;
        Popuptext.text = text;
        PopupScroll.SetActive(true);
    }

    protected override void stopActionOnClick()
    {
        base.stopActionOnClick();
        PopupScroll.SetActive(false);
    }
    private void evaluateReadingPage()
    {
        if (PlayerStats.lastNoteRead >= PlayerStats.actualRoomNumber)
        {
            n = PlayerStats.actualRoomNumber;
        }
        else if (PlayerStats.lastNoteRead < PlayerStats.actualRoomNumber)
        {
            PlayerStats.lastNoteRead++;
            n = PlayerStats.lastNoteRead;
        }
        alreadyReadInThisRoom = true;
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.CompareTag("Player"))
        {
            PopupScroll.SetActive(false);
        }
    }
}
