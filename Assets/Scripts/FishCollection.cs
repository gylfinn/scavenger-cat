using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCollection : MonoBehaviour
{
    private int cherriesCollected = 0;

    [SerializeField]private Text cherriesText;

    [SerializeField] private AudioSource itemCollectingSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            // itemCollectingSound.Play();
            Destroy(collision.gameObject);
            cherriesCollected++;
            cherriesText.text = "Fishies: " + cherriesCollected + "/6"; 
        }    
    }
    
}