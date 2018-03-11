using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	/// <summary>
	/// game object created and assigned value to it
	/// </summary>
	public GameObject PauseUI;
	private bool paused = false;

	void Start(){

		PauseUI.SetActive(false);

	}
	/// <summary>
	/// The player press the ESC button
	/// Enables the pauseUI canvas in uinty and freeze the screen
	/// Disables the pauseUI canvas in unity and unfreeze the screen
	/// </summary>
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
	/// <summary>
	/// Return to the game
	/// </summary>
		
	public void Resume(){
	
		paused = false;		//Return to game

	}
	/// <summary>
	/// Restart the game.
	/// </summary>
	public void Restart () {
		Application.LoadLevel (Application.loadedLevel);
	}
	/// <summary>
	/// "1" is the index number if Main menu
	/// </summary>
	public void MainMenu() {
		Application.LoadLevel ("StartMenu"); // "1" is the index number of Main menu
	}
	public void Quit () {
		Application.Quit ();
	}
}
