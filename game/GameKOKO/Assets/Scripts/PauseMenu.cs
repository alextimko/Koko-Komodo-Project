using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	private bool paused = false;

	void Start(){

		PauseUI.SetActive(false);

	}
	void Update () {
		if (Input.GetButtonDown ("Pause")) {	///When player press the ESC button
			paused = !paused;
		}
		if (paused) {
			PauseUI.SetActive (true);		///Enables the PauseUI canvas in unity
			Time.timeScale = 0;			///Freeze the screen
		}
		if (!paused) {
			PauseUI.SetActive (false);		///Disables the PauseUi canvas in unity
			Time.timeScale = 1;			///Unfreeze the screen
		}
	}
		
	public void Resume(){
	
		paused = false;		//Return to game

	}
	public void Restart () {
		Application.LoadLevel (Application.loadedLevel);
	}
	public void MainMenu() {
		Application.LoadLevel ("StartMenu"); // "1" is the index number of Main menu
	}
	public void Quit () {
		Application.Quit ();
	}
}
