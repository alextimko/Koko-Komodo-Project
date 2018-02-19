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
			healthBar.value -= 4.5f;
			curHealth = healthBar.value;
			StartCoroutine (player.Knockback (0.02f, 40, player.transform.position));
			redFlash ();
		}
		if (col.gameObject.tag == "Spike") {
			healthBar.value -= 4.2f;
			curHealth = healthBar.value;
			StartCoroutine (player.Knockback (0.02f, 40, player.transform.position));
			redFlash ();
		}
		if (col.gameObject.tag == "meat") {
			healthBar.value -= 4.2f;
			curHealth = healthBar.value;
			col.gameObject.SetActive (false);
			redFlash ();
		}
		if (col.gameObject.tag == "heart") {
			healthBar.value += 4.2f;
			curHealth = healthBar.value;
			col.gameObject.SetActive (false);
		}
		if (curHealth <= 0) {
			GameOverText.SetActive (true);
			RestartButton.SetActive (true);
			Time.timeScale = 0;
		}

	}
	void Update () {
		healthText.text = curHealth.ToString () + " %";
	}
	void redFlash () {
		gameObject.GetComponent<Animation> ().Play ("Red_Flash");
	}
}
