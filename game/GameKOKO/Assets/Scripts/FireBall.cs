﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
	/// <summary>
	/// Velocity of the fire ball
	/// </summary>
	public float velX = 5f; //Velocity for the fire ball
	public float velY = 0f;

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	/// <summary>
	/// Fire ball moves in x direction only because the vely = 0f
	/// </summary>
	void Update () {
		rb2d.velocity = new Vector2 (velX, velY);	//Fire ball move in X dỉrection (because velY = 0f)
		Destroy (gameObject, 3f);  //Destroy fire ball after 3 seconds
	}
}
