using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;

    public bool isPortal2;
    public float distance = 0.2f;

    void Start()
    {
        if (isPortal2 == false)
        {
            destination = GameObject.FindGameObjectWithTag("Portal2").GetComponent<Transform>();
        } else
        {
            destination = GameObject.FindGameObjectWithTag("Portal1").GetComponent<Transform>();
        }    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
            StartCoroutine(Invulnerability());
        }

        
    }

    
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(9, 11, true);
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreLayerCollision(9, 11, false);
    }
}
