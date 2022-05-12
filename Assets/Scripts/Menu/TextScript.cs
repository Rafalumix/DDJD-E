using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class TextScript : MonoBehaviour
{

    public TMP_Text TextComponent;
    private EventTrigger eventTrigger;


    private void Update()
    {
        eventTrigger = GetComponent<EventTrigger>();
            if (eventTrigger != null)
            {
                EventTrigger.Entry enterUIEntry = new EventTrigger.Entry();
                // Pointer Enter
                enterUIEntry.eventID = EventTriggerType.PointerEnter;
                enterUIEntry.callback.AddListener((eventData) => { EnterUI(); });
                eventTrigger.triggers.Add(enterUIEntry);

                //Pointer Exit
                EventTrigger.Entry exitUIEntry = new EventTrigger.Entry();
                exitUIEntry.eventID = EventTriggerType.PointerExit;
                exitUIEntry.callback.AddListener((eventData) => { ExitUI(); });
                eventTrigger.triggers.Add(exitUIEntry);
        }
    }

    public void EnterUI()
    {
        underlineText(); 
    }
    public void ExitUI()
    {
        stopUnderlineText(); 
    }


    public void underlineText()
    {
        TextComponent.fontStyle = FontStyles.Underline; 
    }

    public void stopUnderlineText()
    {
        TextComponent.fontStyle = FontStyles.Normal; 
    }

    void test()
    {
        Debug.Log("You are on the button!"); 
    }
}
