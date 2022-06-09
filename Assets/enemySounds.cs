using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySounds : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    private void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>(), GetComponentInChildren<Rigidbody>());
    }

    public void monsterSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/GROAN_SMALL 3D");
        instance.start();
    }
    public void monsterGetHitSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Gabriel/SkeletonGetHit");
        instance.start();
    }

}
