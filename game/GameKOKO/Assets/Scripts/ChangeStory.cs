using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStory : MonoBehaviour {
	/// <summary>
	/// Duration for the first scene
	/// </summary>
	public float timer = 1f;			//Duration of the first scene
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Application.LoadLevel ("InbetweenCity");
		}
	}
		

}
