using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCatDeath : MonoBehaviour
{


    private void EnemyDeath()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
        
        // deathSound.Play();
        // body.bodyType = RigidbodyType2D.Static;
        // anim.SetTrigger("death_trigger");
        return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.transform.position.y - this.gameObject.transform.position.y + 1.5f);
            if ((collision.gameObject.transform.position.y) > this.gameObject.transform.position.y + 1.5f)
            {
                Debug.Log("Player Y: "+ collision.gameObject.transform.position.y + " Evil Cat Y: "+ (this.gameObject.transform.position.y + 1.5f));
                EnemyDeath();
            }
        }
    }
}
