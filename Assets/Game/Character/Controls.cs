using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	public Camera myCamera;

	private float startTime, endTime;
	private Vector2 dragStart, dragEnd;
	private PlayerContoller player;

	void Start()
	{
		player = FindObjectOfType<PlayerContoller>();
	}

	void Update()
	{
		//TouchControls();
	}

	void TouchControls()
	{
		if (player.grounded)
		{
			if (Input.GetMouseButtonDown(0))
			{
				DragStart();
			}
			if (Input.GetMouseButtonUp(0))
			{
				DragEnd();				
			}
		}
	}

	public void DragStart()
	{
		// Capture time and position of drag start
		dragStart = CalculateWorldPointOfMouseClick();
		startTime = Time.time;		
	}

	public void DragEnd()
	{
		// Jump
		dragEnd = CalculateWorldPointOfMouseClick();
		endTime = Time.time;
		
		float dragDuration = endTime - startTime;
		if (dragDuration > 1) { dragDuration = 1; }
		float launchSpeedY = ((((dragEnd.y - dragStart.y)/16)/ dragDuration)+4.75f);
		float launchQualifierX = (dragEnd.x - dragStart.x);
		float dragAve = dragEnd.y - dragStart.y;
		float launchSpeedX = 0;
		if (player.transform.position.x < 6 && launchQualifierX > 2)
		{
			launchSpeedX = 0.5f;
		}
		if (launchSpeedY > 7.5f) { launchSpeedY = 7.5f; }
		Vector3 JumpVelocity = new Vector3(launchSpeedX, launchSpeedY, 0);
		if (player.grounded)
		{
			player.Jump(JumpVelocity);
		}
	}

	Vector2 CalculateWorldPointOfMouseClick()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);


		return worldPos;
	}
}
