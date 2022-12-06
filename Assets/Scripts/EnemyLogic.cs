using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLogic : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    [SerializeField]private GameObject player;
    [SerializeField]private float jumpForce = 15f;
    [SerializeField]private float jumpLength = 3;
    [SerializeField]private float MinDistanceToPlayerToJump = 10;
    private bool isJumping = false;
    [SerializeField]private bool jumpDir = false;
    private bool firstJump;
    private enum MovementState {idle,jumping}
    MovementState state;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 10, true);
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (tag == "DeadEnemy")
        {
            Debug.Log(tag);
        }
        
        if (Vector3.Distance (transform.position, player.transform.position) < MinDistanceToPlayerToJump)
        {
            if (isJumping == false)
            {
                if (!firstJump)
                {
                    EnemyCatJumping();
                    firstJump = true;
                }
                
                Invoke("EnemyCatJumping", 2);//this will happen after 2 seconds
                isJumping = true;
            }
        }

        if (body.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (body.velocity.y < -0.1f)
        {
            state = MovementState.jumping;
        }
        else
        {
            state = MovementState.idle;
        }
        anim.SetInteger("state", (int)state);
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
