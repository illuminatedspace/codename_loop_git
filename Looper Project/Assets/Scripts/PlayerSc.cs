using UnityEngine;
using System.Collections;

public class PlayerSc : MonoBehaviour {

    public float speed = 10f;   // Variable that multiplies the force applied to the rigidbody.
    public float jumpVelocity = 50f; // Variable determining the sudden vertical force applied to the rigidbody.
    public LayerMask groundLayerTest;
    public float walkSpeed;


    private float moveVertical = 0f;
    private Rigidbody2D rb; // Declares a variable of type RigidBody2D game component.
    private bool facingRight = false;
	private Animator MyAnimator;



    void Start() // This function Attaches this script to the rigidbody that is also a  part of this scripts object.
	{
		rb = GetComponent<Rigidbody2D>(); // Gets the Rigidbody2D component that is attached to the same asset as this script.
		MyAnimator = GetComponent<Animator>();
	}





	void Update () // This function reads in the Vertical/Horizontal input of the player, and applys force to the rigidbody accordingly.
	{


		float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        bool isJumping = MyAnimator.GetBool("Jump");
        moveVertical = 0f;

        if (Input.GetButtonDown ("Jump") && rb.IsTouchingLayers (groundLayerTest)) {
            StartJump();
		}

        //Sets the landing animator bool to true if the sprite is not touching the ground
        //AND is moving negative vertically
        if (!rb.IsTouchingLayers(groundLayerTest) && !isJumping) {
            StartFall();
        } else {
            EndFall();
        }




        //Code to control the running animation and which direction the character should be facing
        if (moveHorizontal != 0) {
            MyAnimator.SetBool("Running", true);

            if (moveHorizontal < 0 && !facingRight) {
                Flip();
            } else if (moveHorizontal > 0 && facingRight) {
                Flip();
            }

        } else {
            MyAnimator.SetBool("Running", false);
        }


        // Code to move Rigidbody2d left and right
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector3.left * Time.deltaTime * walkSpeed, Camera.main.transform);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector3.right * Time.deltaTime * walkSpeed, Camera.main.transform);
        }

        //Code to apply jump if StartJump was called
        Vector3 movement = new Vector3 (0.0f, moveVertical, 0.0f);
		rb.AddForce(movement);

	}




    // Functions*************************************************************



    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void StartJump()
    {
        moveVertical = jumpVelocity;
        
        MyAnimator.SetBool("Jump", true);
        Debug.Log("Jummpin up");
        
        Invoke("EndJumpAnimation", 0.4f);
    }



    void EndJumpAnimation()
    {
        MyAnimator.SetBool("Jump", false);
    }





    void StartFall()
    {
        MyAnimator.SetBool("Falling", true);
        Debug.Log("Starting fall animation.");
    }





    void EndFall()
    {
        MyAnimator.SetBool("Falling", false);
        Debug.Log("Ending fall animation.");
    }
}
