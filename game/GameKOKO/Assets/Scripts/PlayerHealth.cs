﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour {
	/// <summary>
	/// gets the health bar from unity.
	/// </summary>
	[SerializeField]
	Slider healthBar;	//get the health bar from unity
	/// <summary>
	/// gets the health text.
	/// </summary>
	[SerializeField]
	Text healthText;	//get the health text from unity

	private Player player;
	private float timer = 3.6f;

	float maxHealth = 100;
	float curHealth;

	Animator anim;

	public GameObject GameOverText, RestartButton, game;

	private GameObject meat;

	void Start () {
		GameOverText.SetActive (false);
		RestartButton.SetActive (false);
		healthBar.value = maxHealth;
		curHealth = healthBar.value;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		 
	}
	/// <summary>
	/// Things that happens when the character collides with the "tag" objects
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerStay2D (Collider2D col) {	//When the character collides with the "tag" objects
		if (curHealth > 0) {
			if (col.gameObject.tag == "Saw") {	
				SoundManager.PlaySound ("meat");
				healthBar.value -= 5f;	//minus health from health bar
				curHealth = healthBar.value;	
				StartCoroutine (player.Knockback (0.02f, 40, player.transform.position));	//activate knock back
				redFlash ();	//red flash animation when character lose health
			}
			if (col.gameObject.tag == "Spike") {
				SoundManager.PlaySound ("meat");
				healthBar.value -= 10f;
				curHealth = healthBar.value;
				StartCoroutine (player.Knockback (0.02f, 40, player.transform.position));
				redFlash ();
			}
			if (col.gameObject.tag == "meat") {
				SoundManager.PlaySound ("meat");
				healthBar.value -= 10f;
				curHealth = healthBar.value;
				col.gameObject.SetActive (false);
				redFlash ();
			}
			if (col.gameObject.tag == "heart") {
				SoundManager.PlaySound ("health");
				healthBar.value += 20f;
				curHealth = healthBar.value;
				col.gameObject.SetActive (false);
			}
		}
		else if (curHealth <= 0 ) {	//current health of the character equals to 0 so the game is over
			DestroyObject (game);
			SoundManager.PlaySound ("gameOver");
			Destroy (player);
			Time.timeScale = 0f;
			GameOverText.SetActive (true);
			timer -= Time.deltaTime;
			if (timer <= 0) {
				Application.LoadLevel ("Scene");
			}

		}
			

	}
	void Update () {
		healthText.text = curHealth.ToString () + " %";

		if (player.transform.position.y < -5) {	//when the character is falling off the ground, game is over
			DestroyObject (game);
			SoundManager.PlaySound ("gameOver");
			Time.timeScale = 0f;
			GameOverText.SetActive (true);
			timer -= Time.deltaTime + 0.05f;
			if (timer <= 0) {
				Application.LoadLevel ("Scene");
			}
				
		}
	}
	/// <summary>
	/// activates the animation
	/// </summary>
	void redFlash () {
		gameObject.GetComponent<Animation> ().Play ("Red_Flash");	//activate the animation
	}
}
