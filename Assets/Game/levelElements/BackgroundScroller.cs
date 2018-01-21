using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed, tileSizeX;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
		transform.position = startPosition + Vector3.left * newPosition;
	}
}
