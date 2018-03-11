using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {
	/// <summary>
	/// The saw speed intialized.
	/// </summary>
	float sawSpeed = 300;
	/// <summary>
	/// Rotates the saw
	/// </summary>
	void Update () {
		transform.Rotate (0, 0, sawSpeed * Time.deltaTime);	//rotate the saw
	}
}
