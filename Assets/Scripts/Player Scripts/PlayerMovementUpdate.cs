using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUpdate : MonoBehaviour
{

    //int var


    public Vector2 moveSpeed;
    public float normalSpeed = 3.0f;
    public float dashing = 5.0f;
    public float jumpForce = 300f;


    private Animator animator;
    private Rigidbody2D _rigidbody;


    //for flip
    private bool facingRight = true;

    //for move
    public float horizontalMovement;
    public float VerticalMovement;

    //for jump 
    public Transform groundCheck;
    public float checkRadius;
    private bool isGrounded;
    public LayerMask whatIsGround;
    private bool isJumping = false;

    //for double jump
    private int extraJumps;
    public int extraJumpsValue;


    //for dash
    private int extraDash;
    public int extraDashValue;
    public GameObject dashEffect;
    public float DashForce;
    public float StartDashTimer;
    bool isDashing;
    float DashDirection;
    float currentDashTimer;




    void Start()
    {
   	 animator = GetComponent<Animator>();
	_rigidbody = GetComponent<Rigidbody2D>();

        extraJumps = extraJumpsValue;
        extraDash = extraDashValue;
        moveSpeed = new Vector2(3f, 0f);
    }

    void FixedUpdate()
    {
        float characterSpeed = Mathf.Abs(_rigidbody.velocity.x);
        animator.SetFloat("Speed", characterSpeed);
		
        animator.SetBool("isGrounded", isGrounded);

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed.x;
        VerticalMovement = Input.GetAxis("Vertical") * moveSpeed.y;

        _rigidbody.velocity = new Vector2(horizontalMovement, _rigidbody.velocity.y);



        if (facingRight == false && horizontalMovement > 0)
        {
            Flip();
        }
        else if (facingRight== true && horizontalMovement <0)
        {
            Flip();
        }

        if(isGrounded == true)
        {
            extraJumps = 1;
            extraDash = 1;
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps>0)
        {  
             animator.SetBool("isJumping", true);
            //FindObjectOfType<AudioManagerScript>().Play("Jump_Sound");
            isJumping = true;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(new Vector2(0, jumpForce));
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            //FindObjectOfType<AudioManagerScript>().Play("Jump_Sound");
            _rigidbody.velocity = Vector2.up * jumpForce;
        } 


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (extraDash >= 1)
            {
                isDashing = true;
                //FindObjectOfType<AudioManager>().Play("dash");

                currentDashTimer = StartDashTimer;
                _rigidbody.velocity = Vector2.zero;
                DashDirection = (int)horizontalMovement;
                --extraDash;
            }

        }
        if (isDashing)
        {
            _rigidbody.velocity = transform.right * DashDirection * DashForce;
            currentDashTimer -= Time.deltaTime;

            if (currentDashTimer < 0)
            {
                isDashing = false;
                --extraDash;
            }
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }




}
