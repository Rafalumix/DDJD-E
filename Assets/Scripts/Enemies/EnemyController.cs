using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int lifePoints = 50;
    [SerializeField] private int damage = 10;
    [SerializeField] private int givenXP = 6;
    [SerializeField] private int fromWhichDepthItAppears = 0;    
    //private bool canEmitSound = true;


    PlayerController mainCharacter;
    RoomManager roomManager; 

    Collider _collider; 
    Animator _animator;
    enemySounds _sound;
    void Start()
    {
        mainCharacter = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
        roomManager = GameObject.Find("GameManager").GetComponent<RoomManager>();
        StartCoroutine(randomGroan());

        if (PlayerStats.actualRoomNumber >= fromWhichDepthItAppears)
        {
            lifePoints += PlayerStats.actualRoomNumber * 10;
            damage += PlayerStats.actualRoomNumber * 3; 
            _animator = GetComponent<Animator>();
            _collider = GetComponentInChildren<Collider>();
            _sound = GetComponent<enemySounds>();
        } else
        {
            roomManager.reduceEnemies();
            Destroy(this.gameObject); 
        }
    }

    public void attack()
    {

        if (!_animator.GetBool("isDead"))
        {
            _animator.SetTrigger("Attack");
            mainCharacter.takeDamage(damage);
            /*if (canEmitSound == true)
            {
                StartCoroutine(randomGroan());
            }*/
        }
    }

    public void takeDamage(int damage)
    {
        _animator.SetTrigger("Hit");
        _sound.monsterGetHitSound(); 
        lifePoints -= damage;
        Debug.Log(lifePoints);
        if (lifePoints <= 0)
        {
            die(); 
        }
    }
    private IEnumerator randomGroan()
    {
        int n = Random.Range(5, 15);

        yield return new WaitForSeconds(n);

        if (!_animator.GetBool("isDead"))
        {
            _sound.monsterSound();
        }
        StartCoroutine(randomGroan()); 
    }
    private void die()
    {
        if (!_animator.GetBool("isDead"))
        {
            mainCharacter.gainXp(givenXP); 
            _collider.enabled = false; 
            _animator.SetBool("isDead", true);
            roomManager.reduceEnemies();
            roomManager.checkOpenPowerUpWindow(); 
            //Destroy(this.gameObject); 
        }  
    }
    public void reborn()
    {
        _collider.enabled = true;
        _animator.SetBool("isDead", false);
        }

    public bool isAttacking()
    {
        return _animator.GetBool("isAttacking");
    }

    public void EndAttack() 
    {
        _animator.SetBool("isAttacking", false);
    }
}
