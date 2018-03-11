using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Camera follow class.
/// </summary>
public class CameraFollow : MonoBehaviour {
	/// <summary>
	/// The velocity a player.
	/// </summary>
	private Vector2 velocity;
	/// <summary>
	/// position of the player in y direction
	/// </summary>
	public float smoothTimeY;

	/// <summary>
	/// position of the player in y direction
	/// </summary>
	public float smoothTimeX;
	/// <summary>
	/// The player game object created.
	/// </summary>
	public GameObject player;

	public bool bounds;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	/// <summary>
	/// camera following and add booundary for the camera
	/// </summary>
	void FixedUpdate (){
		//Camera Following
		float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x,smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y,smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

		//Add boundary for the camera
		if(bounds){
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x), 
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	
	}
}
