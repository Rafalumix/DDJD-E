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
    EnemyIA _IA; 
    enemySounds _sound;


    void Start()
    {
        mainCharacter = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
        roomManager = GameObject.Find("GameManager").GetComponent<RoomManager>();
        _IA = GetComponent<EnemyIA>(); 
        StartCoroutine(randomGroan());

        if (PlayerStats.actualRoomNumber >= fromWhichDepthItAppears)
        {
            lifePoints += PlayerStats.actualRoomNumber * 5;
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
        if (!_animator.GetBool("isDead") && _IA.isAlive())
        {
          
            _animator.SetTrigger("Attack");
            // _animator.SetBool("isAttacking", true);
            // mainCharacter.takeDamage(damage);
            /*if (canEmitSound == true)
            {
                StartCoroutine(randomGroan());
            }*/
        }
    }

    public void takeDamage(int damage)
    {

        if( Random.Range(1,100)<= 25)
            _animator.SetTrigger("Hit");

        _sound.monsterGetHitSound(); 
        lifePoints -= damage;
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
            _IA.Kill(); 
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
        StartCoroutine(makeHimMove()); 
    }
    private IEnumerator makeHimMove()
    {
        yield return new WaitForSeconds(1.5f);
        _IA.Reborn(); 
    }

    public bool isAttacking()
    {
        return _animator.GetBool("isAttacking");
    }

    public void EndAttack() 
    {
        _animator.SetBool("isAttacking", false);
    }

    public void StartAttack() 
    {
        _animator.SetBool("isAttacking", true);
    }

    public int GetDamage() 
    {
        return damage;
    }
}