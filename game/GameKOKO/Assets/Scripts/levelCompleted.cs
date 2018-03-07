using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelCompleted : MonoBehaviour {

	public void Map () { 				///***Application.LoadLevel -- load level base on "Name of the scene"
		Application.LoadLevel ("Map"); 
	}
	public void MainMenu () {
		Application.LoadLevel ("StartMenu");
		PlayerPrefs.SetInt("currentScore",0);
	}
	public void NextLevel () {
		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
	public void Restart () {
		Application.LoadLevel (Application.loadedLevel);

	}
}
