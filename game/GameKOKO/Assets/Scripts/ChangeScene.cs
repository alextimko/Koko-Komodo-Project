using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	public float timer = 3.6f;			//Duration of the first scene
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Application.LoadLevel ("StartMenu");
		}
	}
}
