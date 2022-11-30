using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    [SerializeField]
    private FloatSo playerLives;

    [SerializeField] private AudioSource deathSound;
    
    [SerializeField]private Text playerText;
    [SerializeField]private LayerMask enemyLayer;


    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerText.text = "Lives: " + playerLives.Value + "/9"; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerDeath();
        }
        else if (collision.gameObject.CompareTag("Dog"))
        {
            PlayerDeath();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if ((collision.gameObject.transform.localPosition.y + 1.5f) > this.transform.localPosition.y)
            {
                Debug.Log("Player Y: "+ this.transform.localPosition.y + " Evil Cat Y: "+ (collision.gameObject.transform.localPosition.y + 1.5f));
                PlayerDeath();
            }
        }

    }


 
    private void PlayerDeath()
    {
        deathSound.Play();
        body.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death_trigger");
        playerLives.Value--;
 

            //game over screen

    }

 

    //reloads current level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
