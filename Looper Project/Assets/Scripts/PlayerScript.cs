using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerScript : MonoBehaviour {

    // public variables
    [Tooltip("Players top running speed")]
    public float horizontalSpeed;
    [Tooltip("Players jump velocity")]
    public float jumpForce;
    [Tooltip("Maximum length of time player can rise while holding jump button")]
    public float jumpTimeMax;

    [Tooltip("Used to tell what gameObject layers should be considered the ground")]
    public LayerMask whatIsGround;

    [Tooltip("groundCheck should be child object of the player, beneath their feet")]
    public Transform groundCheck;

    // private variables
    private Rigidbody2D rb;
    private Animator myAnimator;
    private float jumpTimeCounter, groundCheckRadius;
    private bool facingRight;


    void Start () {
        InitializePrivateVariables();
	}
	
	void Update () {
        float movement = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        ObjectMovement(movement);
        HandleAnimation(grounded,movement);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            PlayerJump();
        } else if (Input.GetKeyUp(KeyCode.Space) && !grounded) {
            ReduceJumpCounter(jumpTimeMax + 1f);
        } else if (Input.GetKey(KeyCode.Space) && jumpTimeCounter > 0) {
            PlayerJump();
            ReduceJumpCounter(Time.deltaTime);
        } else if (grounded) {
            JumpCounterReset();
        }
	}


    // Non-Update Functions

    void ObjectMovement(float horInput) {
        rb.transform.Translate(new Vector2 (horInput, 0));
    }

    void HandleAnimation(bool groundCheck, float moveValue) {
        if(moveValue < 0 && facingRight) {
            FlipCharacterDirection();
        } else if (moveValue > 0 && !facingRight) {
            FlipCharacterDirection();
        }

        myAnimator.SetFloat("Speed", Mathf.Abs(moveValue));
        myAnimator.SetBool("Grounded", groundCheck);
    }

    void PlayerJump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void ReduceJumpCounter(float counter) {
        jumpTimeCounter -= counter;
        Debug.Log("JumpCounter being reduced by " + counter + ". Time Left on counter is " + jumpTimeCounter);
    }

    void JumpCounterReset() {
        jumpTimeCounter = jumpTimeMax;
    }

    void FlipCharacterDirection() {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    // private variable initializer
    void InitializePrivateVariables() {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        facingRight = true;
        groundCheckRadius = 0.1f;
    }

}
