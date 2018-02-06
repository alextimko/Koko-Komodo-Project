using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

	public float velX = 5f;
	public float velY = 0f;

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2 (velX, velY);
		Destroy (gameObject, 3f);
	}
}
