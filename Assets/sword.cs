using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private EnemyController enemyController;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered in a collider!");

        if (other.tag == "enemy")
        {
                Debug.Log("Enemy hitted!");
                enemyController = other.GetComponent<EnemyController>();
                enemyController.takeDamage(PlayerStats.vigor.getFlatDamage()); 
            
        }
    }

}
