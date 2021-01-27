using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    //MOVEMENT//
    private Rigidbody2D rb;
    private bool facingRight;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public Animator animator;
    public float cooldownTime;
    private float nextFireTime;
    public float movementSpeed;
    private float defaultSpeed;
    private float runSpeed;

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

    //ATACK//
    public Transform attack;

    //SOUNDS//
    public AudioSource jumping;
    public AudioSource dashing;

    //STATS//
    public PlayerStats ps;
    private bool canWallSlide = false;
    private bool canDash = false;
    
    void Start(){
        
        movementSpeed = ps.getSpeed();
        defaultSpeed = movementSpeed;
        runSpeed = defaultSpeed * 1.5f;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        feetPos.position = new Vector2(feetPos.position.x, feetPos.position.y - 0.385f);
        facingRight = true;
        nextFireTime = 0f;

    }

    void FixedUpdate(){

        move();

        run();

    }

    void Update(){

        jump();

        if(canWallSlide){
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

            Flip();

        }else if(movement > 0 && !facingRight){

            animator.Play("Walk");

            Flip();
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

        if(Time.time > nextFireTime){

            var input = Input.GetAxis("Horizontal");

            if(direction == 0){

                if(Input.GetKeyDown(KeyCode.LeftControl)){

                    if(input < 0){

                        direction = 1;

                    }else if (input > 0){

                        direction = 2;

                    }

                    dashing.Play();
                    
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

                        if(isGrounded){
                            
                            rb.velocity = Vector2.left * dashSpeed;

                        }else{

                            rb.velocity = Vector2.left * (dashSpeed * 0.5f);

                        }

                    }else if(direction == 2){

                        animator.Play("Dash");
                        
                        if(isGrounded){
                            
                            rb.velocity = Vector2.right * dashSpeed;

                        }else{

                            rb.velocity = Vector2.right * (dashSpeed * 0.5f);
                            
                        }

                    }

                    nextFireTime = Time.time + cooldownTime;
                    input = 0;
                    direction = 0;

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
            jumping.Play();
            

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
            Invoke("SetWallJumpingToFalse", wallJumpTime);
            jumping.Play();

        }

        if(wallJumping){

            rb.velocity = new Vector2(xWallForce * -input, yWallForce);
            
        }
    }

    void SetWallJumpingToFalse(){

        wallJumping = false;

    }

    void Flip(){

        float f1 = 1.9f;
        float f2 = -2.8f;

        if(!facingRight){
            attack.localPosition = new Vector3(-attack.localPosition.x, 0f, 0f);
            frontCheck.transform.localPosition = new Vector3(f1, 0f, 0f);
        }else{
            attack.localPosition = new Vector3(-attack.localPosition.x, 0f, 0f);
            frontCheck.transform.localPosition = new Vector3(f2, 0f, 0f);
        }

        facingRight = !facingRight;

    }

    public bool Grounded(){

        return isGrounded;

    }

    void OnTriggerStay2D(Collider2D collider){

        switch(collider.tag){

            case "Stairs":

                transform.position = new Vector2(transform.position.x, transform.position.y);

                if(Input.GetKey(KeyCode.W)){

                    rb.velocity = new Vector2(0f, movementSpeed);

                }else if(Input.GetKey(KeyCode.S)){

                    rb.velocity = new Vector2(0f, -movementSpeed);

                }else{

                    rb.velocity = new Vector2(0f, 0f);

                }

                break;

        }

    }

    public void canPlayerWallSlide(bool wallsliding){

        canWallSlide = wallsliding;

    }

    public void canPlayerDash(bool dash){

        canDash = dash;

    }
    
}
