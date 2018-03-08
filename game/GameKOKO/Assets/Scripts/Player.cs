using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public float maxSpeed = 3;	//Set the max Speed of character is 3
	public float speed = 10f;
	public float jumpPower = 15f;

	public bool facingRight;	//Check the character is facing right or not
	public bool grounded;	//Check the character is grounded or not
	public bool canDoubleJump;	//Check the character can use double jump or not

	public int curHealth;		//Current health
	public int maxHealth = 100; 	//Max health

	private Rigidbody2D rb2d;
	private Animator anim;


	public GameObject FireBallLeft, FireBallRight;  //Find and get all informations of this game object in unity

	public GameObject levelCompleted, levelIncompleted;	

	public GameObject gameInstruction, gameInstructionText;

	Vector2 fireBallPos;		//get the fire ball position
	public float fireRate = 0.5f;
	float nextFire = 0.5f;
	// Use this for initialization

	public static int count = 0; //fruit collecting count
	public Text countText;
	private int tokencount;
	public Text tokencountText;

	public GameObject game;


	void Start () 
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		levelCompleted.SetActive (false);
		levelIncompleted.SetActive (false);
		count = PlayerPrefs.GetInt("currentScore");
		tokencount = 0;
		SetCountText ();
		SetTokenCountText ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool ("Grounded",grounded);
		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));
		Destroy (gameInstruction, 4f);	//Show the controller instruction at the beginning of City Intro 
		Destroy (gameInstructionText, 4f);
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (-1, 1, 1);	//Character is facing left, flip the side of character to left
			facingRight = false;
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (1, 1, 1);	//Character is facing right
			facingRight = true;
		}
		if (Input.GetButtonDown ("Jump")) {	//when player press space
			SoundManager.PlaySound ("jump");	//Player the sound
			if (grounded) {
				rb2d.AddForce (Vector2.up * (jumpPower + 20f)); //First jump and character can use the double jump
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
					rb2d.AddForce (Vector2.up * (jumpPower - 30f)); //Second jump and the power of this second jump is lower than the first
				}
			}
		}
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {	//When player press F key
			SoundManager.PlaySound ("fire");
			fire ();
			anim.SetBool ("attack", true);	//Animation for attack

		}
		if (Input.GetButtonUp ("Fire1")) {	//When character stand still and shoot
			SoundManager.PlaySound ("fire");
			anim.SetBool ("attack", false);
			anim.SetBool ("runandshoot", false);
		}
		if (Input.GetButtonDown ("Fire1") && GetComponent<Rigidbody2D> ().velocity.x > 0) { //when character run and shoot in right direction
			SoundManager.PlaySound ("fire"); 
			anim.SetBool ("attack", false);
			anim.SetBool ("runandshoot", true);
		}
		if (Input.GetButtonDown ("Fire1") && GetComponent<Rigidbody2D> ().velocity.x < 0) {//when character run and shoot in left direction
			SoundManager.PlaySound ("fire");
			anim.SetBool ("attack", false);
			anim.SetBool ("runandshoot", true);
		}
	}

	void FixedUpdate () 
	{
		Vector3 easeVelocity = rb2d.velocity; //create invisible friction to stop the character immediately when he stop moving
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;;
		easeVelocity.x *= 0.60f;
		float h = Input.GetAxis ("Horizontal");

		//Fake friction *** easing the x speed of the player
		if(grounded) {
			rb2d.velocity = easeVelocity;
		}

		//Moving player
		rb2d.AddForce ((Vector2.right * speed) * h);

		//Limiting the speed of player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	
	}
	void fire () {	//function for fire ball
		fireBallPos = transform.position;
		if (facingRight) {
			fireBallPos += new Vector2 (+0.35f, 0.45f);
			Instantiate (FireBallRight, fireBallPos, Quaternion.identity);
		} else {
			fireBallPos += new Vector2 (-0.35f, 0.45f);
			Instantiate (FireBallLeft, fireBallPos, Quaternion.identity);
		}
	}

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir) {//knock back duration, power amd direction
		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime;
			rb2d.velocity = new Vector2 (0, 0);
			rb2d.AddForce (new Vector3 (knockbackDir.x * -20, 40, transform.position.z));
		}

		yield return 0;
	}


	void OnTriggerEnter2D(Collider2D collectible)
	{
		if (collectible.gameObject.CompareTag ("apple")) //collide with object following the name tag
		{
			
				SoundManager.PlaySound ("bite");
				collectible.gameObject.SetActive (false);
				count = count + 100;	//add point
				PlayerPrefs.SetInt("currentScore",count);//continue to the next level using the score collected from the previous level
				SetCountText ();

		}
		if (collectible.gameObject.CompareTag ("coin")) 
		{
			SoundManager.PlaySound ("coin");
			collectible.gameObject.SetActive (false);
			tokencount = tokencount + 1;	//add token
			SetTokenCountText ();

		}
		if (collectible.gameObject.CompareTag ("finishflag")) //when player touch the flag
		{
			if (tokencount >= 1) {	//level completed when the token is collected
				DestroyObject (game);
				SoundManager.PlaySound ("levelWin");
				levelCompleted.SetActive (true);
				speed = 0;
				collectible.gameObject.SetActive (false);
			}
			if (tokencount == 0) {	//level incompleted
				DestroyObject (game);
				SoundManager.PlaySound ("gameOver");
				levelIncompleted.SetActive (true);
				collectible.gameObject.SetActive (false);
			}
		}
	}


	void SetCountText()
	{
		countText.text = "Score: " + count.ToString ();	//show the points on screen
	}
	void SetTokenCountText()
	{
		tokencountText.text = "Token: " + tokencount.ToString ();	//show the token on screen
	}



}
