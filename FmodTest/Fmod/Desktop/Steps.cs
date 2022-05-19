using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            instance = FMODUnity.RuntimeManager.CreateInstance("event:/Steps");
            instance.start();
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
        }
    }
}
