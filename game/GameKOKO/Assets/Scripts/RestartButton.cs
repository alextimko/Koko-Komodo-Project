using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {
	/// <summary>
	/// Loads the current level again
	/// </summary>
	public void RestartScene () {
		Application.LoadLevel (Application.loadedLevel);//load the current level again
		PlayerPrefs.SetInt("currentScore",0);
	}
}
