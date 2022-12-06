using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCollection : MonoBehaviour
{
    public float fishCollected = 0;
    bool isOpen = false;

    [SerializeField]private Text fishText;
    [SerializeField]public float totalFish = 1;
    [SerializeField]private GameObject gate;
    [SerializeField]private GameObject levelFinish;
    [SerializeField] private AudioSource itemCollectingSound;
    private GateController gateController;


    void Start()
    {
        gateController = gate.GetComponent<GateController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            itemCollectingSound.Play();
            Destroy(collision.gameObject);
            fishCollected++;
            fishText.text = "Fishies: " + fishCollected + "/" + totalFish; 
        }    
    }

    private void Update()
    {
        if (fishCollected == totalFish && !isOpen)
        {
            // GameObject[] goArray = GameObject.FindGameObjectsWithTag("BlockBox");
            // if (goArray.Length > 0)
            // {
            //     for (int i = 0; i < goArray.Length; i++)
            //     {
            //         goArray[i].SetActive(false);
            //     }
            // }
            // gate = FindObjectOfType<GateController>();
            gateController.OpenGate();
            isOpen = true; 
        }
    }
    
    
}