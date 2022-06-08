using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    private attackAnimationController _attackAnimator;

    private EnemyController enemyController;

    private void Awake()
    {
        _attackAnimator = GetComponentInParent<attackAnimationController>(); 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (_attackAnimator.isAttacking())
        {
            if (other.tag == "enemy")
                    {
                            Debug.Log("Enemy hitted!");
                            enemyController = other.GetComponent<EnemyController>();
                            enemyController.takeDamage(PlayerStats.vigor.getFlatDamage()); 
            
                    }
        }
        
    }

}
