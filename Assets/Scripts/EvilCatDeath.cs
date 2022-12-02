using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCatDeath : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool isDead;
    private Rigidbody2D body;
    [SerializeField]private AudioSource evilcatDeath;

    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    //EnemyDeath gets called through the end of the EvilCat_death animation
    private void EnemyDeath()
    {
        Destroy(this.gameObject);
        // deathSound.Play();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if ((collision.gameObject.transform.position.y) > this.gameObject.transform.position.y + 1.5f)
                {
                    isDead = !isDead;
                    body.bodyType = RigidbodyType2D.Static;
                    boxCollider.enabled = false;
                    evilcatDeath.Play();
                    anim.SetTrigger("death_trigger");
                }

                    
            }
        }
    }
}
