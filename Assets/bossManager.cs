using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossManager : MonoBehaviour
{
    [SerializeField] EnemyController enemy1 = null;
    [SerializeField] EnemyController enemy2 = null;
    [SerializeField] EnemyController enemy3 = null;
    [SerializeField] EnemyController enemy4 = null;

    [SerializeField] GameObject sphere = null;
    bool isGameFinished = false; 

    RoomManager roomManager = null; 

    private int rounds; 
    void Start()
    {
        rounds = 3;
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
            else
            {
                sphere.SetActive(false);
                isGameFinished = true; 
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
