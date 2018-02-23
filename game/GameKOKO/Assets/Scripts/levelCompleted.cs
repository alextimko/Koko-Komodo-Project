using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelCompleted : MonoBehaviour {

	public void Map () {
		Application.LoadLevel (11);
	}
	public void MainMenu () {
		Application.LoadLevel (0);
	}
	public void NextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
	public void Restart () {
		Application.LoadLevel (Application.loadedLevel);
	}
}
