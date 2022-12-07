using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;
    [SerializeField]private GameObject player;
    private PlayerHealth playerLifeLogic;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        playerLifeLogic = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        playerLifeLogic.Add3Lives();
        GameManager.instance.LoadNextLevel();
        // playerLifeLogic.ResetLives();
        // playerLifeLogic.RestartLevel();

    }

}
