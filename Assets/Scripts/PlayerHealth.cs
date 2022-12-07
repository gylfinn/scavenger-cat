using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private AudioSource hurtSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField]private AudioSource dogBark;
    [SerializeField]public FloatSo startingHealth;
    private Animator anim;
    private Rigidbody2D body;
    private BoxCollider2D coll;
    [SerializeField]public FloatSo currentHealth;

   [Header("iFrames")]
    [SerializeField]private float iFramesDuration;
    [SerializeField]private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RottenFish"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
    public void TakeDamage()
    {
        currentHealth.Value -= 1;

        if (currentHealth.Value > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            coll.enabled = false;
            currentHealth.Value -= 1;
            PlayerDeath();
        }
        else if (collision.gameObject.CompareTag("Dog"))
        {
            currentHealth.Value -= 1;
            dogBark.Play();
            PlayerDeath();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if ((collision.gameObject.transform.position.y + 1.5f) > this.transform.position.y)
            {
                currentHealth.Value -= 1;
                PlayerDeath();
            }
        }

    }


    public void PlayerDeath()
    {
        deathSound.Play();
        coll.enabled = false;
        body.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death_trigger");
    }

    public void ResetLives()
    {
        currentHealth.Value = startingHealth.Value;
    }

    public void CallGameOver()
    {
        currentHealth.Value = 9;
        GameManager.instance.GameOver();
    }

    //reloads current level
    public void RestartLevel()
    {
        if (currentHealth.Value <= 0)
        {
            Invoke("CallGameOver",2);
            // GameManager.instance.GameOver();
        }
        else
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {  
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
    private IEnumerator Die()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {  
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
}
