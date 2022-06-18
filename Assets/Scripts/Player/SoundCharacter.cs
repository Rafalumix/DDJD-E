using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCharacter : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
    public void getHitSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/GROAN_SMALL 3D");
        instance.start();
    }
    public void getCriticalHitSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/GROAN_BIG 3D");
        instance.start();
    }
    public void dodgeSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Gabriel/SwordSlashAir");
        instance.start();
    }
    public void blockSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Gabriel/SwordHitShield");
        instance.start();
    }
    public void dringPotionSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Gabriel/Drinking");
        instance.start();
    }
    public void levelUpSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Gabriel/Coins");
        instance.start();
    }

    public void Step() 
    {
        if(animator.GetFloat("Speed") >= 0.1) 
        {
            instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/FOOTSTEPS_STONE");
            instance.start();
        }
    }

}
