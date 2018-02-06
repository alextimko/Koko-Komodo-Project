using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour {

	private playerController player;

	void Start () {
		player = gameObject.GetComponentsInParent<playerController> ();
	}
	void OnTriggerEnter2D(Collider2D col) {
		player.grounded = true;
	
	}
	void OnTriggerExit2D(Collider2D col) {
		player.grounded = false;
	} 
}
