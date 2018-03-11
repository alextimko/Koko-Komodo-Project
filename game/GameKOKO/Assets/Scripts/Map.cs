using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	/// <summary>
	/// All the methods load a scene based on the name of scene
	/// </summary>
	public GameObject gameMap;		

	public void CityIntro () {
		Application.LoadLevel ("InbetweenCity");
	}
	public void SkyLevel () {
		Application.LoadLevel ("SkyLevel");
	}
	public void Back () {
		Application.LoadLevel ("StartMenu");
	}
}
///All the functions above are to load the level base on the name of the scenes