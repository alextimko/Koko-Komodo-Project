using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public float maxSpeed = 3;
	public float speed = 10f;
	public float jumpPower = 15f;

	public bool facingRight;
	public bool grounded;
	public bool canDoubleJump;

	public int curHealth;
	public int maxHealth = 100;

	private Rigidbody2D rb2d;
	private Animator anim;

	public GameObject FireBallLeft, FireBallRight;

	public GameObject levelCompleted, levelIncompleted;

	public GameObject gameInstruction, gameInstructionText;

	Vector2 fireBallPos;
	public float fireRate = 0.5f;
	float nextFire = 0.5f;
	// Use this for initialization

	private int count; //fruit collecting count
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
		count = 0;
		tokencount = 0;
		SetCountText ();
		SetTokenCountText ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool ("Grounded",grounded);
		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));
		Destroy (gameInstruction, 4f);
		Destroy (gameInstructionText, 4f);
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (-1, 1, 1);
			facingRight = false;
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (1, 1, 1);
			facingRight = true;
		}
		if (Input.GetButtonDown ("Jump")) {
			SoundManager.PlaySound ("jump");
			if (grounded) {
				rb2d.AddForce (Vector2.up * (jumpPower + 20f));
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
					rb2d.AddForce (Vector2.up * (jumpPower - 30f));
				}
			}
		}
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
			SoundManager.PlaySound ("fire");
			fire ();
			anim.SetBool ("attack", true);

		}
		if (Input.GetButtonUp ("Fire1")) {
			SoundManager.PlaySound ("fire");
			anim.SetBool ("attack", false);
			anim.SetBool ("runandshoot", false);
		}
		if (Input.GetButtonDown ("Fire1") && GetComponent<Rigidbody2D> ().velocity.x > 0) {
			SoundManager.PlaySound ("fire");
			anim.SetBool ("attack", false);
			anim.SetBool ("runandshoot", true);
		}
		if (Input.GetButtonDown ("Fire1") && GetComponent<Rigidbody2D> ().velocity.x < 0) {
			SoundManager.PlaySound ("fire");
			anim.SetBool ("attack", false);
			anim.SetBool ("runandshoot", true);
		}
	}

	void FixedUpdate () 
	{
		Vector3 easeVelocity = rb2d.velocity;
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
	void fire () {
		fireBallPos = transform.position;
		if (facingRight) {
			fireBallPos += new Vector2 (+0.35f, 0.45f);
			Instantiate (FireBallRight, fireBallPos, Quaternion.identity);
		} else {
			fireBallPos += new Vector2 (-0.35f, 0.45f);
			Instantiate (FireBallLeft, fireBallPos, Quaternion.identity);
		}
	}

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir) {
		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime;
			rb2d.velocity = new Vector2 (0, 0);
			rb2d.AddForce (new Vector3 (knockbackDir.x * -40, 80, transform.position.z));
		}

		yield return 0;
	}

	void OnTriggerEnter2D(Collider2D collectible)
	{
		if (collectible.gameObject.CompareTag ("apple")) 
		{
			SoundManager.PlaySound ("bite");
			collectible.gameObject.SetActive (false);
			count = count + 100;
			SetCountText ();
		}
		if (collectible.gameObject.CompareTag ("coin")) 
		{
			SoundManager.PlaySound ("coin");
			collectible.gameObject.SetActive (false);
			tokencount = tokencount + 1;
			SetTokenCountText ();

		}
		if (collectible.gameObject.CompareTag ("finishflag")) 
		{
			if (tokencount >= 1) {
				DestroyObject (game);
				SoundManager.PlaySound ("levelWin");
				levelCompleted.SetActive (true);
				collectible.gameObject.SetActive (false);
			}
			if (tokencount == 0) {
				DestroyObject (game);
				SoundManager.PlaySound ("gameOver");
				levelIncompleted.SetActive (true);
				collectible.gameObject.SetActive (false);
			}
		}
	}


	void SetCountText()
	{
		countText.text = "Fruit: " + count.ToString ();
	}
	void SetTokenCountText()
	{
		tokencountText.text = "Token: " + tokencount.ToString ();
	}



}
