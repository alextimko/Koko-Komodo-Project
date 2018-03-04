using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
	private Player player;

	void Start () {
		player = gameObject.GetComponentInParent<Player> ();	
	}
	void OnTriggerEnter2D (Collider2D col){	//Detect player is on the ground or not
		if (null == player) {
			Start ();
		}
		player.grounded = true;
	}
	void OnTriggerStay2D (Collider2D col) {///Player on the ground
		player.grounded = true;
	}
	void OnTriggerExit2D (Collider2D col){///Player not on the ground
		player.grounded = false;
	}
	
}
