using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip biteSound, gameOverSound, jumpSound, fireSound, healthSound, coinSound, meatSound;
	static AudioSource audioSrc;

	void Start () {
		biteSound = Resources.Load<AudioClip> ("bite");
		gameOverSound = Resources.Load<AudioClip> ("gameOver");
		jumpSound = Resources.Load<AudioClip> ("jump");
		coinSound = Resources.Load<AudioClip> ("coin");
		fireSound = Resources.Load<AudioClip> ("fire");
		healthSound = Resources.Load<AudioClip> ("health");
		meatSound = Resources.Load<AudioClip> ("meat");

		audioSrc = GetComponent<AudioSource> ();
	}

	public static void PlaySound (string clip) {
		switch (clip) {
		case "bite":
			audioSrc.PlayOneShot (biteSound);
			break;
		case "jump":
			audioSrc.PlayOneShot (jumpSound);
			break;
		case "gameOver":
			audioSrc.PlayOneShot (gameOverSound);
			break;
		case "fire":
			audioSrc.PlayOneShot (fireSound);
			break;
		case "coin":
			audioSrc.PlayOneShot (coinSound);
			break;
		case "health":
			audioSrc.PlayOneShot (healthSound);
			break;
		case "meat":
			audioSrc.PlayOneShot (meatSound);
			break;

		}
	}
}	

