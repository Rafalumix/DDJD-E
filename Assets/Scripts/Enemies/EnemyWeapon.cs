using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private EnemyController _attackAnimator;

    private SwordSounds _sound; 

    private PlayerController playerController;

    private void Awake()
    {
        _attackAnimator = GetComponentInParent<EnemyController>(); 
        _sound = GetComponent<SwordSounds>();
    }


    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(_attackAnimator.isAttacking());
        if (_attackAnimator.isAttacking())
        {

            if (other.tag == "Player")
            {
                Debug.Log("Player hitted!");
                playerController = other.GetComponent<PlayerController>();
                playerController.takeDamage(_attackAnimator.GetDamage());
                _attackAnimator.EndAttack();
    
            }
            else if(other.tag == "wall")
            {
                _sound.hitWallSound(); 
                Debug.Log("wall");
            }
            else if (other.tag == "wood")
            {
                _sound.hitWoodSound(); 
                Debug.Log("wood"); 
            } 
            else if (other.tag == "metal")
            {
                _sound.hitMetalSound(); 
                Debug.Log("metal");
            }
        }
        
    }

}
