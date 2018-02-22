using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public GameObject gameMap;

	public void CityIntro () {
		Application.LoadLevel (1);
	}
	public void SkyLevel () {
		Application.LoadLevel (12);
	}
	public void Back () {
		Application.LoadLevel (0);
	}
}
