using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {
	/// <summary>
	/// The background scroll speed assigned.
	/// </summary>
	float backgroundScrollSpeed = -.5f;
	Vector2 startingPosition;

	void Start () 
	{
		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	/// <summary>
	/// Back ground position
	/// </summary>
	void Update () 
	{
		float newPosition = Mathf.Repeat (Time.time * backgroundScrollSpeed, 5);
		transform.position = startingPosition + Vector2.right * -newPosition;
	}
}
