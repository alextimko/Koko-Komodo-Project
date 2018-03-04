using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyLevel : MonoBehaviour {

	public GameObject Levels;

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
	public void Back(){
		Application.LoadLevel ("Map");
	}
}
