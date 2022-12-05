using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private float startingHealth;
    [SerializeField]private AudioSource hurtSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField]private AudioSource dogBark;
    private Animator anim;
    private Rigidbody2D body;
    public float currentHealth {get; private set;}
    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RottenFish"))
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        currentHealth -= 1;

        if (currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
            hurtSound.Play();
        }
        else
        {
            //player dead
            PlayerDeath();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage();
        }
    }

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
        else if (collision.gameObject.CompareTag("Dog"))
        {
            dogBark.Play();
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


    public void PlayerDeath()
    {
        deathSound.Play();
        body.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death_trigger");
        
        if (currentHealth <= 0)
        {
            //game over screen
            GameManager.instance.GameOver();
        }
    }

    public void ResetLives()
    {
        currentHealth = startingHealth;
    }

    //reloads current level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
