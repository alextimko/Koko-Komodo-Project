using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void PlayGame()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); ///Load next scene
	}
	public void New () {
		Application.LoadLevel ("StoryIntro");
	}

	public void Map () {
		Application.LoadLevel ("Map");
	}

	public void QuitGame()
	{
		Debug.Log ("QUIT");
		Application.Quit (); ///Quit Game, works after game is built
	}
	public void HighScore () {
		Application.LoadLevel ("Scene");
	}
}
