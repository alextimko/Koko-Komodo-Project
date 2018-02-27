using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyLevel : MonoBehaviour {

	public GameObject Levels;

	public void Level1 () {
		Application.LoadLevel (3);
	}

	public void Level2 () {
		Application.LoadLevel (5);
	}

	public void Level3 () {
		Application.LoadLevel (7);
	}

	public void Level4 () {
		Application.LoadLevel (9);
	}
	public void Back(){
		Application.LoadLevel (11);
	}
}
