using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLogic : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField]private GameObject player;
    [SerializeField]private float jumpForce = 15f;
    [SerializeField]private float jumpLength = 3;
    private bool isJumping = false;
    [SerializeField]private bool jumpDir = false;
    private bool firstJump;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Vector3.Distance (transform.position, player.transform.position) < 10)
        {
            if (isJumping == false)
            {
                if (!firstJump)
                {
                    EnemyCatJumping();
                    firstJump = true;
                }
                Debug.Log(jumpDir);
                Invoke("EnemyCatJumping", 2);//this will happen after 2 seconds
                isJumping = true;
            }
        }
    }

    private void EnemyCatJumping()
    {
        if (jumpDir)
        {
            body.velocity = new Vector2(jumpLength, jumpForce);
        }
        else
        {
            body.velocity = new Vector2(-jumpLength, jumpForce);
        }
        jumpDir = !jumpDir;
        isJumping = !isJumping;
    }


}
