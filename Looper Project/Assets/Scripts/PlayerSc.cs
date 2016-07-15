using UnityEngine;
using System.Collections;

public class PlayerSc : MonoBehaviour {

    // Variables ************************************************************

    public float speed = 10f;   // variable that multiplies the force applied to the rigidbody.
    public float jumpVelocity = 50f; // variable determining the sudden vertical force applied to the rigidbody.
    public LayerMask groundLayerTest;
    public float walkSpeed;

    private float moveVertical = 0f;
    private Rigidbody2D rb; // declares a variable of type RigidBody2D game component.
    private bool facingRight = false;
	private Animator MyAnimator;



    // Main Methods ************************************************************

    void Start() // attaches this script to the rigidbody that is also a  part of this scripts object.
	{
		rb = GetComponent<Rigidbody2D>(); // gets the Rigidbody2D component that is attached to the same asset as this script.
		MyAnimator = GetComponent<Animator>();
	}



	void Update () // reads in the Vertical/Horizontal input of the player, and applys force to the rigidbody accordingly.
	{
		float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        //bool isJumping = MyAnimator.GetBool("Jump");
        //bool isFalling = MyAnimator.GetBool("Falling");
        moveVertical = 0f;

        if (Input.GetButtonDown ("Jump") && rb.IsTouchingLayers (groundLayerTest)) {
            StartJump();
        }

        //starts the landing animation
        if (rb.IsTouchingLayers(groundLayerTest) && MyAnimator.GetBool("Falling") == true)
        {
            EndFall();
            Land();
        }

        // code to control the running animation and which direction the character should be facing
        if (moveHorizontal != 0)
        {
            MyAnimator.SetBool("Running", true);

            if (moveHorizontal < 0 && !facingRight)
            {
                Flip();
            }
            else if (moveHorizontal > 0 && facingRight)
            {
                Flip();
            }
        }
        else
        {
            MyAnimator.SetBool("Running", false);
        }

        // code to move Rigidbody2d left and right
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * walkSpeed, Camera.main.transform);
            Debug.Log("Moving Left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * walkSpeed, Camera.main.transform);
            Debug.Log("Moving Right");
        }

        // code to apply jump if StartJump was called
        Vector3 movement = new Vector3 (0.0f, moveVertical, 0.0f);
		rb.AddForce(movement);

	}



    // Custom Methods ************************************************************

    void Flip()
    {
        // switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // multiplies the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void StartJump()
    {
        moveVertical = jumpVelocity; // causes the character to jump up with the force entered in jump velocity on the character

        MyAnimator.SetBool("Jump", true);
        Debug.Log("Jummpin up");

        //Invoke("EndJumpAnimation", 0.4f); // goes to EndJumpAnimation to make falling work correctly
    }



    //void EndJumpAnimation()
    //{
    //    MyAnimator.SetBool("Jump", false);
    //}



    void StartFall()
    {
        MyAnimator.SetBool("Jump", false);
        MyAnimator.SetBool("Falling", true);
        Debug.Log("Starting fall animation.");
    }



    void EndFall()
    {
        MyAnimator.SetBool("Falling", false);
        Debug.Log("Ending fall animation.");
    }

    void Land()
    {
        MyAnimator.SetBool("Landing", true);
        Debug.Log("Landing.");
    }

    void EndLand()
    {
        MyAnimator.SetBool("Landing", false);
        Debug.Log("Ending Landing.");
    }
}
