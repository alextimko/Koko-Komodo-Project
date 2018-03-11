using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	/// <summary>
	/// Loads the next level.
	/// </summary>
	public void PlayGame()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); ///Load next scene
	}
	/// <summary>
	/// loads the story of the game
	/// </summary>
	public void New () {
		Application.LoadLevel ("StoryIntro");
	}
	/// <summary>
	/// Loads the map of the game
	/// </summary>
	public void Map () {
		Application.LoadLevel ("Map");
	}
	/// <summary>
	/// Quits the game, It works after the game is built.
	/// </summary>
	public void QuitGame()
	{
		Debug.Log ("QUIT");
		Application.Quit (); ///Quit Game, works after game is built
	}
	/// <summary>
	/// The high score scene is loaded.
	/// </summary>
	public void HighScore () {
		Application.LoadLevel ("Scene");
	}
}
