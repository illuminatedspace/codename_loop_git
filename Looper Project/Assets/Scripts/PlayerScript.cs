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
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        ObjectMovement(Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime);
        HandleAnimation(grounded);

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
        rb.transform.Translate(new Vector2(horInput, 0));
    }

    void HandleAnimation(bool groundCheck) {
        myAnimator.SetFloat("Speed", rb.velocity.x);
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


    // private variable initializer
    void InitializePrivateVariables() {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        facingRight = false;
        groundCheckRadius = 0.1f;
    }

}
