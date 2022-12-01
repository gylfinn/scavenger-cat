using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCatDeath : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;

    private void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    //EnemyDeath gets called through the end of the EvilCat_death animation
    private void EnemyDeath()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
        
        // deathSound.Play();

        return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if ((collision.gameObject.transform.position.y) > this.gameObject.transform.position.y + 1.5f)
            {
                body.bodyType = RigidbodyType2D.Static;
                anim.SetTrigger("death_trigger");
            }
        }
    }
}
