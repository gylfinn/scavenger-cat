using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;



    private float directionX = 0f;
    private bool doubleJump;


    [SerializeField]private LayerMask wallLayer;
    [SerializeField]private LayerMask jumpableGround;
    //sama og að gera variables public til að unity sjái
    [SerializeField]private float movementSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;


    private enum MovementState {idle,running,jumping,climbing,falling}

    [SerializeField] private AudioSource jumpSound;

    [Header("Wall Jumping")]
    public float wallJumpTime = 0.1f;
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = 1.0f;
    private bool isWallSliding = false;
    RaycastHit2D wallCheckHit;
    float jumpTime;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        directionX = Input.GetAxisRaw("Horizontal");

        //move left or right
  
        body.velocity = new Vector2(directionX * movementSpeed, body.velocity.y);
 

        if (IsPlayerGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
    
        if ((Input.GetButtonDown("Jump") && (IsPlayerGrounded() || doubleJump)) || (isWallSliding && Input.GetButtonDown("Jump")))
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            doubleJump = !doubleJump;
        }

        //The longer you hold jump button the higher to jump
        if (Input.GetButtonUp("Jump") && body.velocity.y > 0f)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
        }

        //Wall Jumping
        if (directionX > 0f)
        {
            wallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, wallLayer);
            // Debug.DrawRay(transform.position, new Vector2(wallDistance, 0), Color.blue);
        }
        else 
        {
            wallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, wallLayer);
            // Debug.DrawRay(transform.position, new Vector2(-wallDistance, 0), Color.blue);
        }
        
        if (wallCheckHit && !IsPlayerGrounded() && directionX != 0)
        {
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
        }
        else if (jumpTime < Time.time)
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            body.velocity = new Vector2(body.velocity.x, Mathf.Clamp(body.velocity.y, wallSlideSpeed, float.MaxValue));
        }
        UpdateAnimation();

        
    }

    //check if Player touches the terrain
    private bool IsPlayerGrounded()
    {
        // return Physics2D.OverlapCircle(coll.bounds.center, 1.0f, jumpableGround);
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
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
            state = MovementState.jumping;
        }
            
        if (isWallSliding)
        {
            state = MovementState.climbing;
        }
        anim.SetInteger("state", (int)state);
    }
}
