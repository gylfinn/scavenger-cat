using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogLogic : MonoBehaviour
{
    private bool isBarking;
    [SerializeField]private GameObject player;

    private void Update()
    {
        if (Vector3.Distance (transform.position, player.transform.position) < 10)
        {
            if (isBarking == false)
            {
                Invoke("DogBarking", 2);//this will happen after 2 seconds
                isBarking = true;
            }
        }
    }

    private void DogBarking()
    {
        //Play Bark Sound;
        isBarking = !isBarking;
    }
}
