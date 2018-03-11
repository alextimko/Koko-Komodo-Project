using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
	/// <summary>
	/// Instance variable of Player type of created
	/// </summary>
	private Player player;
	/// <summary>
	/// player game object intiated
	/// </summary>
	void Start () {
		player = gameObject.GetComponentInParent<Player> ();	
	}
	/// <summary>
	/// Detect the position of the player if it is on the ground or not
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D (Collider2D col){	//Detect player is on the ground or not
		if (null == player) {
			Start ();
		}
		player.grounded = true;
	}
	/// <summary>
	/// player is on the ground
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerStay2D (Collider2D col) {///Player on the ground
		player.grounded = true;
	}
	/// <summary>
	/// Player is not on the ground
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerExit2D (Collider2D col){///Player not on the ground
		player.grounded = false;
	}
	
}
