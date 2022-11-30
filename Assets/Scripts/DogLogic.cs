using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogLogic : MonoBehaviour
{
    private bool isBarking;
    private bool firstBark;
    [SerializeField]private AudioSource dogsound;
    [SerializeField]private GameObject player;

    private void Update()
    {
        if (Vector3.Distance (transform.position, player.transform.position) < 10)
        {
            if (isBarking == false)
            {
                if (!firstBark)
                {
                    DogBarking();
                    firstBark = true;
                }
                Invoke("DogBarking", 3);//this will happen after 2 seconds
                isBarking = true;
            }
        }
    }

    private void DogBarking()
    {
        //Play Bark Sound;
        dogsound.Play();
        isBarking = !isBarking;
    }
}
