using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
	/// <summary>
	/// Duration fo the first scene
	/// </summary>
	public float timer = 3.6f;			//Duration of the first scene
	/// <summary>
	/// Load StartMenu when timer less than or eqal to zero
	/// </summary>
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Application.LoadLevel ("StartMenu");
		}
	}
}
