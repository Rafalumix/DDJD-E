using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScrollInteraction : Interactable
{
    [SerializeField] GameObject PopupScroll = null;
    [SerializeField] TMP_Text Popuptitle = null;
    [SerializeField] TMP_Text Popuptext = null;

    override protected void doActionOnClick()
    {
        base.doActionOnClick(); 
        string title = ScrollManager.readTitle(1);
        string text = ScrollManager.readText(1);
        Popuptitle.text = title;
        Popuptext.text = text;
        PopupScroll.SetActive(true); 
    }

    protected override void stopActionOnClick()
    {
        base.stopActionOnClick();
        PopupScroll.SetActive(false);
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.CompareTag("Player"))
        {
            PopupScroll.SetActive(false);
        }
    }
}
