using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {
	/// <summary>
	/// Rotates the saw following Y direction
	/// </summary>
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3 (0,45,0)* Time.deltaTime); ///Rotate the saw follow Y direction
	}
}
