using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	public float maxSpeed;
	public float jumpHeight;
	public bool grounded;

	bool facingRight;

	bool canDoubleJump;

	Rigidbody2D myBody;
	Animator myAnim;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

		facingRight = true;
	}


	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		myAnim.SetBool ("grounded", grounded);
		myAnim.SetFloat ("speed", Mathf.Abs (move));
		myBody.velocity = new Vector2 (move * maxSpeed, myBody.velocity.y);

		if (move > 0 && !facingRight) {
			flip ();		
		} else if (move < 0 && facingRight) {
			flip ();
		}
		//single jump code
		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			if (grounded) {
				myBody.AddForce (Vector2.up * jumpHeight);
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					myBody.velocity = new Vector2 (myBody.velocity.x, 0);
					myBody.AddForce (Vector2.up * jumpHeight);
				}
			}
		}
	}



	void flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	/*void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Ground") {
			grounded = true;
			canDoubleJump = false;

		}
	}*/

	}



