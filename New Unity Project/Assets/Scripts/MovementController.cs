using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;

    Animator anim;
    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
     //   anim = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float move = Input.GetAxis("Horizontal");
       // anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

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

}
