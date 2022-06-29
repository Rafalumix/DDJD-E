using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD; 

public class Sounds : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    public void clickButtonSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/MENU_SELECT");
        instance.start(); 
    }

    public void clickConfirmButtonSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/MENU_VALIDATE");
        instance.start();
    }
    public void openDoorSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/DOOR OPEN");
        instance.start();
    }
    public void roomCompletedSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/CHEST");
        instance.start();
    }
    public void ScrollReadingSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/BOOK_1");
        instance.start();
    }
}
