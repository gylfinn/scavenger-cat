using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;
    private PlayerHealth playerHealth;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        playerHealth.Add3Lives();
        GameManager.instance.LoadNextLevel();
        // playerLifeLogic.ResetLives();
        // playerLifeLogic.RestartLevel();

    }

}
