using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyLevel : MonoBehaviour {
	/// <summary>
	/// game object created
	/// </summary>
	public GameObject Levels;
	/// <summary>
	///loads scenes in between.
	/// </summary>
	public void Level1 () {
		Application.LoadLevel ("Inbetween0");
	}

	public void Level2 () {
		Application.LoadLevel ("Inbetween1");
	}

	public void Level3 () {
		Application.LoadLevel ("Inbetween2");
	}

	public void Level4 () {
		Application.LoadLevel ("Inbetween3");
	}
	/// <summary>
	/// Back to the map scene.
	/// </summary>
	public void Back(){
		Application.LoadLevel ("Map");
	}
}
