using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float maxSpeed = 10f;
    public float jumpForce = 100f;
    public float thrust = 10f;
    bool facingRight = true;
    bool isGrounded = false;

    Animator anim;
    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
     //   anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        groundedUpdater(); //Check the character is touching the ground to prevent double jumps

        float move = Input.GetAxis("Horizontal");
       // anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //Make Char jump
        if (Input.GetKeyDown("space"))
        {
            if (isGrounded == true)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                // transform.Translate(Vector2.up * jumpForce * Time.deltaTime, Space.World);
                isGrounded = false;
            }
            
        }

        //Flip picture depending on orientation
        if(move > 0 && !facingRight)
        {
            FlipFacing();
        }
        else if(move < 0 && facingRight)
        {
            FlipFacing();
        }
	
	}

    void FlipFacing()
    {
        facingRight = !facingRight;
        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;
    }

    void groundedUpdater()
    {
        isGrounded = false;
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(transform.position, Vector2.down, 1.2f);

        foreach (var hited in hit)
        {
            if (hited.collider.gameObject == gameObject) //Ignore the character
                continue;

            if (hited.collider.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }
    }

}
