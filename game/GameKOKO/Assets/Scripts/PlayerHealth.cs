using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	[SerializeField]
	Slider healthBar;
	[SerializeField]
	Text healthText;

	private Player player;

	float maxHealth = 100;
	float curHealth;


	public GameObject GameOverText, RestartButton, meat;

	void Start () {
		GameOverText.SetActive (false);
		RestartButton.SetActive (false);
		healthBar.value = maxHealth;
		curHealth = healthBar.value;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.tag == "Saw") {
			SoundManager.PlaySound ("meat");
			healthBar.value -= 4.5f;
			curHealth = healthBar.value;
			StartCoroutine (player.Knockback (0.02f, 40, player.transform.position));
			redFlash ();
		}
		if (col.gameObject.tag == "Spike") {
			SoundManager.PlaySound ("meat");
			healthBar.value -= 4.2f;
			curHealth = healthBar.value;
			StartCoroutine (player.Knockback (0.02f, 40, player.transform.position));
			redFlash ();
		}
		if (col.gameObject.tag == "meat") {
			SoundManager.PlaySound ("meat");
			healthBar.value -= 4.2f;
			curHealth = healthBar.value;
			col.gameObject.SetActive (false);
			redFlash ();
		}
		if (col.gameObject.tag == "heart") {
			SoundManager.PlaySound ("health");
			healthBar.value += 4.2f;
			curHealth = healthBar.value;
			col.gameObject.SetActive (false);
		}
		if (curHealth <= 0) {
			SoundManager.PlaySound ("gameOver");
			GameOverText.SetActive (true);
			RestartButton.SetActive (true);
		}
			

	}
	void Update () {
		healthText.text = curHealth.ToString () + " %";

		if (player.transform.position.y < -5) {
			SoundManager.PlaySound ("gameOver");
			Time.timeScale = 1f;
			GameOverText.SetActive (true);
			RestartButton.SetActive (true);
		}
	}
	void redFlash () {
		gameObject.GetComponent<Animation> ().Play ("Red_Flash");
	}
}
