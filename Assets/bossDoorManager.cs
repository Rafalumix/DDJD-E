using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDoorManager : Interactable
{
    bossManager bossManager;

    private Sounds _sound = null;

    private void Awake()
    {
        bossManager = GameObject.Find("GameManager").GetComponent<bossManager>();

        _sound = GameObject.Find("Music").GetComponent<Sounds>();
    }
    override protected void OnTriggerEnter(Collider other)
    {
        if (bossManager.unlockedSecretEnding())
        {
            base.OnTriggerEnter(other);
        }

    }
    override protected void doActionOnClick()
    {
        Debug.Log("You touched " + gameObject.name);

        if (bossManager.unlockedSecretEnding())
        {
            if (_sound != null)
            {
                _sound.openDoorSound();
            }
            Debug.Log("SECRET ENDING"); 
        }
    }
}
