using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private int playerlives;
    [SerializeField]private Text playerText;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDeath();
        }
    }

    private void RemoveLifefromText()
    {
        playerText.text = "Lives: " + playerlives + "/9"; 
    }
    private void PlayerDeath()
    {
        deathSound.Play();
        body.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death_trigger");
        playerlives--;
        if (playerlives == 0)
        {
            //game over screen
        }
    }

    //reloads current level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
