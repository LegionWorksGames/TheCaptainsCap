using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour {

	private Rigidbody2D rb;
	private Controls controls;
	private Animator anim;
	/*these floats are the force you use to jump, the max time you want your jump to be allowed to happen,
     * and a counter to track how long you have been jumping*/
	public float jumpForce;
	public float jumpTime;
	public float jumpTimeCounter;
	/*this bool is to tell us whether you are on the ground or not
     * the layermask lets you select a layer to be ground; you will need to create a layer named ground(or whatever you like) and assign your
     * ground objects to this layer.
     * The stoppedJumping bool lets us track when the player stops jumping.*/
	public bool grounded, extra;
	public LayerMask whatIsGround;
	public bool stoppedJumping;

	/*the public transform is how you will detect whether we are touching the ground.
     * Add an empty game object as a child of your player and position it at your feet, where you touch the ground.
     * the float groundCheckRadius allows you to set a radius for the groundCheck, to adjust the way you interact with the ground*/

	public Transform groundCheck;
	public float groundCheckRadius;

	void Start()
	{
		print(GameManager.UPGRADE[0]);
		//sets the jumpCounter to whatever we set our jumptime to in the editor
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		jumpTimeCounter = jumpTime;
	}

	void Update()
	{		
		MovementCatch();
		Abilities();
		//determines whether our bool, grounded, is true or false by seeing if our groundcheck overlaps something on the ground layer
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


		//if we are grounded...
		if (grounded)
		{
			//the jumpcounter is whatever we set jumptime to in the editor.
			jumpTimeCounter = jumpTime;
			extra = false;
		}
		anim.SetBool("grounded", grounded);
		//if you press down the mouse button...
		if (Input.GetKeyDown("space"))
		{
			//and you are on the ground...
			print("mousedown");
			if (grounded)
			{
				//jump!
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				stoppedJumping = false;
			}
			//if (!grounded && transform.position.x < 6 && !extraPush && stoppedJumping)
			//{
			//	rb.velocity = new Vector2(1.5f, rb.velocity.y);
			//	extraPush = true;
			//}
		}
		//if you stop holding down the mouse button...
		if (Input.GetKeyUp("space"))
		{
			//stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}
	}

	void FixedUpdate()
	{
		//I placed this code in FixedUpdate because we are using phyics to move.
		//if you keep holding down the mouse button...
		if ((Input.GetKey("space")) && !stoppedJumping)
		{
			//and your counter hasn't reached zero...
			if (jumpTimeCounter > 0)
			{
				//keep jumping!
				float forceX = rb.velocity.x;
				if (jumpTimeCounter < jumpTime/2 && jumpTimeCounter > jumpTime/4) { forceX = 0.5f; }
				rb.velocity = new Vector2(forceX, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}		
	}

	public void Jump(Vector3 JumpVelocity)
	{
		rb.velocity = JumpVelocity;
	}

	void MovementCatch()
	{
		if (transform.position.x < 3)
		{
			transform.position += Vector3.right * Time.deltaTime;
		}
		if (transform.position.x > 3 && grounded)
		{
			transform.position -= Vector3.right * (0.5f *Time.deltaTime);
		}
	}

	void Abilities()
	{
		if (GameManager.UPGRADE[0] >= 0)
		{
			print("glide Unlocked");
			//glide
			if (Input.GetKeyDown("space") && stoppedJumping && !grounded && !extra)
			{				
				float forceX = ((GameManager.UPGRADE[0]/2) + 0.5f /* * Time.deltaTime */);
				rb.velocity = new Vector2(forceX, rb.velocity.y);
				print("this happened");
				extra = true;
			}
		}
		if (GameManager.UPGRADE[1] == 10 && !extra)
		{
			print("drop Unlocked");
			if (Input.GetKeyDown(KeyCode.DownArrow) && !grounded)
			{
				rb.velocity = new Vector2(0, -2);
				extra = true;
			}
		}
		if (GameManager.UPGRADE[2] == 5)
		{
			print("speed Unlocked");
			//glide
			if (Input.GetKey("RightArrow") /* && grounded? */)
			{
				int forceX = ((GameManager.UPGRADE[2] - 4) / 10 /* * Time.deltaTime */);
				rb.velocity = new Vector2(forceX, rb.velocity.y);
			}
		}
	}
}
