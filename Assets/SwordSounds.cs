using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSounds : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    private void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>(), GetComponentInChildren<Rigidbody>());
    }

    public void hitWoodSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Gabriel/swordHitWoord");
        instance.start();
    }
    public void hitWallSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Gabriel/SwordScrashWall");
        instance.start();
    }
    public void hitMetalSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Gabriel/swordHitMetal");
        instance.start();
    }
}
