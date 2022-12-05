using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private float startingHealth;
    [SerializeField]private PlayerLife life;
    [SerializeField]private AudioSource hurtSound;
    private Animator anim;
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
            life.PlayerDeath();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage();
        }
    }

}
