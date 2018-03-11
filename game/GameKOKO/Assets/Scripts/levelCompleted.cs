using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelCompleted : MonoBehaviour {
	/// <summary>
	/// Loads levels based on the Name of the scene
	/// </summary>
	public void Map () { 				///***Application.LoadLevel -- load level base on "Name of the scene"
		Application.LoadLevel ("Map"); 
	}
	/// <summary>
	///Loads Mains the menu.
	/// Set the current score and current token to zero every time a new game starts
	/// </summary>
	public void MainMenu () {
		Application.LoadLevel ("StartMenu");
		PlayerPrefs.SetInt("currentScore",0);
		PlayerPrefs.SetInt ("currentToken",0);
	}
	/// <summary>
	/// Loads the next level.
	/// </summary>
	public void NextLevel () {
		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
	/// <summary>
	/// Restart the level
	/// </summary>
	public void Restart () {
		Application.LoadLevel (Application.loadedLevel);

	}
	/// <summary>
	/// Shows the high score scene.
	/// </summary>
	public void ShowHighScore () {

		SceneManager.LoadScene ("Scene");
	}
}
