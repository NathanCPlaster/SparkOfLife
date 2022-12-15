using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LifeSystem : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public GameObject[] lives;
    private int life;
    private bool dead;

    private void Start()
    {
        life = lives.Length;
    }

    void Update()
    {
        if(dead == true)
        {
            Debug.Log("PLAYER IS DEAD");
            OnPlayerDeath?.Invoke();
            Time.timeScale = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if(life >= 1)
        {
            life -= damage;
            Destroy(lives[life].gameObject);
            if (life < 1)
            {
                dead = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDamage(1);
        }
    }
}
