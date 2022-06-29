using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossManager : MonoBehaviour
{
    [SerializeField] EnemyController enemy1 = null;
    [SerializeField] EnemyController enemy2 = null;
    [SerializeField] EnemyController enemy3 = null;
    [SerializeField] EnemyController enemy4 = null;
    private int secondsToWait = 10;

    [SerializeField] GameObject PopupText = null;
    [SerializeField] GameObject PopupSecretEndingText = null;


    [SerializeField] GameObject sphere = null;
    bool isGameFinished = false; 

    RoomManager roomManager = null;

    [SerializeField] private int rounds; 
    void Start()
    {
        roomManager = GetComponent<RoomManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (roomManager.canGoInTheNextRoom())
        {
            if (rounds > 1)
            {
                StartCoroutine(nextRound());
            }
            else if (!isGameFinished)
            {
                sphere.SetActive(false);
                isGameFinished = true; 
                StartCoroutine(EndPopUp());
            }
        }
    }
    public bool unlockedSecretEnding()
    {
        if (isGameFinished && ScrollManager.isUnlockedSecretEnding())
        {
            return true; 
        }
        return false; 
    }

    private IEnumerator EndPopUp(){
        PopupText.SetActive(true);
        yield return new WaitForSeconds(secondsToWait);
        PopupText.SetActive(false);
        if (ScrollManager.isUnlockedSecretEnding())
        {
            PopupSecretEndingText.SetActive(true);
            yield return new WaitForSeconds(secondsToWait);
            PopupSecretEndingText.SetActive(false);
        }
    }

    private IEnumerator nextRound()
    {
        rounds--;
        roomManager.bossRoundRefill(); 

        yield return new WaitForSeconds(5);

        enemy1.reborn();
        enemy2.reborn();
        enemy3.reborn();
        enemy4.reborn();
    }
}
