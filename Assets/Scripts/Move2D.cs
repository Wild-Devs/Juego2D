using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{

    //CHECKS//
    public bool canWalk;
    public bool canJump;
    public bool canDash;
    public bool canWallJump;

    //MOVEMENT//
    public float movementSpeed;
    public float defaultSpeed;
    private float runSpeed;
    private Rigidbody2D rb;
    private bool facingRight;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public Animator animator;

    //JUMP//
    private bool isGrounded;
    public float radius;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    //WALLJUMP//
    private bool isTouchingFront;
    public Transform frontCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;
    private bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    
    void Start(){

        runSpeed = defaultSpeed * 1.5f;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    void FixedUpdate(){


        if(canWalk){
            move();

            run();
        }

    }

    void Update(){


        if(canJump){
            jump();
        }
        if(canWallJump){
            wallSlide();
        }
        if(canDash){
            dash();
        }

    }


    void move(){

        var movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.fixedDeltaTime * movementSpeed;

        if(movement < 0 && facingRight){

            animator.Play("Walk");

            flip();

        }else if(movement > 0 && !facingRight){

            animator.Play("Walk");

            flip();
        }
    }

    void run(){
        if(Input.GetKey(KeyCode.LeftShift)){

            movementSpeed = runSpeed;

        }else{

            movementSpeed = defaultSpeed;

        }
    }

    void dash(){

        var input = Input.GetAxis("Horizontal");

        if(direction == 0){

            if(Input.GetKeyDown(KeyCode.LeftControl)){

                if(input < 0){

                    direction = 1;

                }else if (input > 0){

                    direction = 2;

                }
            }

        }else{

            if(dashTime <= 0){

                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;

            }else{

                dashTime -= Time.deltaTime;

                if(direction == 1){

                    animator.Play("Dash");

                    rb.velocity = Vector2.left * dashSpeed;

                }else if(direction == 2){

                    animator.Play("Dash");

                    rb.velocity = Vector2.right * dashSpeed;

                }

            }

        }

    }

    void jump(){

        isGrounded = Physics2D.OverlapCircle(feetPos.position, radius, whatIsGround);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){

            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;

        }

        if(Input.GetKey(KeyCode.Space) && isJumping){

            if(jumpTimeCounter > 0){

                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;

            }else{

                isJumping = false;

            }
        }

        if(Input.GetKeyUp(KeyCode.Space)){

            isJumping = false;

        }
    }

    void wallSlide(){
        
        float input = Input.GetAxis("Horizontal");

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, radius, whatIsGround);
        
        if(isTouchingFront && !isGrounded && input != 0){

            wallSliding = true;

        }else{

            wallSliding = false;

        }

        if(wallSliding){

            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));

        }

        if(Input.GetKeyDown(KeyCode.Space) && wallSliding){

            wallJumping = true;
            Invoke("setWallJumpingToFalse", wallJumpTime);

        }

        if(wallJumping){

            rb.velocity = new Vector2(xWallForce * -input, yWallForce);
        }
    }

    void setWallJumpingToFalse(){

        wallJumping = false;

    }

    void flip(){

        float f1 = 2.8f;
        float f2 = -2.8f;

        if(!facingRight){
            frontCheck.transform.localPosition = new Vector3(f1, 0f, 0f);
        }else{
            frontCheck.transform.localPosition = new Vector3(f2, 0f, 0f);
        }

        facingRight = !facingRight;

    }

}
