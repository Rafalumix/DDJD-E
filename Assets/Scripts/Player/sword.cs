using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sword : MonoBehaviour
{
    private attackAnimationController _attackAnimator;

    private SwordSounds _sound; 

    private EnemyController enemyController;

    private void Awake()
    {
        _attackAnimator = GetComponentInParent<attackAnimationController>(); 
        _sound = GetComponent<SwordSounds>();
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (_attackAnimator.isAttacking())
        {
            Debug.Log("attacking");
            if (other.tag == "enemy")
                    {
                        CinemachineCameraShaker.instance.ShakeCamera(0.02f,10,20);
                        Debug.Log("Enemy hitted!");
                        enemyController = other.GetComponent<EnemyController>();
                        enemyController.takeDamage(PlayerStats.vigor.getFlatDamage()); 
            
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
            } else if (other.tag == "metal")
            {
                _sound.hitMetalSound(); 
                Debug.Log("metal");
            } else if (other.tag == "boss")
            {
                SceneManager.LoadScene(GetSceneName.EndingVideo);
            }
        }
        
    }

}
