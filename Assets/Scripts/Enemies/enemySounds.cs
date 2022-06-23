using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySounds : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    private string[] nameOfRandomGroans = { "Skeleton Groan_1_3d", "Skeleton Groan_2_3d",
                                            "Skeleton Groan_3_3d", "Skeleton Groan_4_3d"}; 

    private void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>(), GetComponentInChildren<Rigidbody>());
    }

    public void monsterSound()
    {
        int n = Random.Range(0, 4);
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Pablo/" + nameOfRandomGroans[n]);
        instance.start();
    }
    public void monsterGetHitSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Gabriel/SkeletonGetHit");
        instance.start();
    }

}
