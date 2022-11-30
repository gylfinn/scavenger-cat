using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCatDeath : MonoBehaviour
{
    [SerializeField]private GameObject enemy;
    private void EnemyDeath()
    {
        enemy.tag = "DeadEnemy";
        Destroy(enemy);
        
        // deathSound.Play();
        // body.bodyType = RigidbodyType2D.Static;
        // anim.SetTrigger("death_trigger");
        return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyDeath();
        }
    }
}
