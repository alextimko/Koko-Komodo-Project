﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour {
	/// <summary>
	/// declare a variable of type of AudioMixer
	/// </summary>
	public AudioMixer audioMixer;	//declare variable
	/// <summary>
	/// variables of AudioClip type decleared
	/// </summary>
	public static AudioClip biteSound, gameOverSound, jumpSound, fireSound, 
	healthSound, coinSound, meatSound, levelWinSound;	//declare variables
	static AudioSource audioSrc;
	/// <summary>
	/// gets the sound based on the name in unity
	/// </summary>
	void Start () {
		biteSound = Resources.Load<AudioClip> ("bite");	//get the sound base on name in unity
		gameOverSound = Resources.Load<AudioClip> ("gameOver");
		jumpSound = Resources.Load<AudioClip> ("jump");
		coinSound = Resources.Load<AudioClip> ("coin");
		fireSound = Resources.Load<AudioClip> ("fire");
		healthSound = Resources.Load<AudioClip> ("health");
		meatSound = Resources.Load<AudioClip> ("meat");
		levelWinSound = Resources.Load<AudioClip> ("levelWin");

		audioSrc = GetComponent<AudioSource> ();
	}
	/// <summary>
	/// Based on the situation of the character different sounds are played
	/// </summary>
	/// <param name="clip">Clip.</param>

	public static void PlaySound (string clip) {
		switch (clip) {	//these sounds are played depend on what case we are having
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
		case "levelWin":
			audioSrc.PlayOneShot (levelWinSound);
			break;

		}
	}
	/// <summary>
	/// Sets the volume.
	/// </summary>
	/// <param name="volume">Volume.</param>
	public void SetVolume(float volume) {
		Debug.Log (volume);
		audioMixer.SetFloat ("volume", volume);
	}
}	

