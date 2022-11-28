using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D coll;
    // private Animator anim;
    private SpriteRenderer sprite;



    private float directionX = 0f;
   


    // [SerializeField]private LayerMask wallLayer;
    [SerializeField]private LayerMask jumpableGround;
    //sama og að gera variables public til að unity sjái
    [SerializeField]private float movementSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;


    private enum MovementState {idle,running,jumping,falling}

    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        // anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");

        //move left or right
  
        body.velocity = new Vector2(directionX * movementSpeed, body.velocity.y);
 

       

        if (Input.GetButtonDown("Jump") && IsPlayerGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }

        //The longer you hold jump button the higher to jump
        if (Input.GetButtonUp("Jump") && body.velocity.y > 0f)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
        }


        UpdateAnimation();

        
    }

    //check if Player touches the terrain
    private bool IsPlayerGrounded()
    {
        return Physics2D.OverlapCircle(coll.bounds.center, 1.0f, jumpableGround);
        // return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else
        {
            state = MovementState.idle;
        }

        if (body.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (body.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        // anim.SetInteger("state", (int)state);
    }
}
