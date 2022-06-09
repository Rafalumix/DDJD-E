using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int lifePoints = 100;
    [SerializeField] private int damage = 20;
    //private bool canEmitSound = true;


    PlayerController mainCharacter;

    Collider _collider; 
    Animator _animator;
    enemySounds _sound; 

    void Start()
    {
        mainCharacter = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _collider = GetComponentInChildren<Collider>();
        _sound = GetComponent<enemySounds>(); 
    }

    public void attack()
    {
        if (!_animator.GetBool("isDead"))
        {
            mainCharacter.takeDamage(damage);
            /*
            if (canEmitSound == true)
            {
                StartCoroutine(randomGroan());
            }*/
        }
    }

    public void takeDamage(int damage)
    {
        _sound.monsterGetHitSound(); 
        lifePoints -= damage;
        if (lifePoints <= 0)
        {
            die(); 
        }
    }
    /*private IEnumerator randomGroan()
    {
        int n = Random.Range(5, 15);
        canEmitSound = false;

        yield return new WaitForSeconds(n);

        canEmitSound = true;
        if (!_animator.GetBool("isDead"))
        {
            _sound.monsterSound();
        }
    }*/
    private void die()
    {
        if (!_animator.GetBool("isDead"))
        {
            _collider.enabled = false; 
            _animator.SetBool("isDead", true); 
            //Destroy(this.gameObject); 
        }
       
    }
}
