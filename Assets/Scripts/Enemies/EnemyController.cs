using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int lifePoints = 100;
    [SerializeField] private int damage = 20;

    PlayerController mainCharacter; 

    void Start()
    {
        mainCharacter = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
    }

    public void attack()
    {
        mainCharacter.takeDamage(damage);
    }

    public void takeDamage(int damage)
    {
        lifePoints -= damage;
        if (lifePoints <= 0)
        {
            die(); 
        }
    }

    private void die()
    {
        Destroy(this.gameObject); 
    }
}
