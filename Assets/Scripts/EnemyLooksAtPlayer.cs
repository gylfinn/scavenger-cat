using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLooksAtPlayer : MonoBehaviour
{

    [SerializeField]private Transform player;
    private bool flip;
    void Update()
    {
        Vector2 scale = transform.localScale;
        if (player.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }
        transform.localScale = scale;
    }
}
