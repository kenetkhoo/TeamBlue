﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour {

	/// <summary>
	/// 1 - The speed of the drop
	/// </summary>
	public Vector2 speed = new Vector2(50, 50);

	// 2 - Store the movement;
	private Vector2 movement;

	private bool facingRight = true;

	void Update()
	{
	}

	void FixedUpdate()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis ("Horizontal");
		
		// 4 - Movement per direction
		movement = new Vector2 (
			speed.x * inputX,
			0);
		if(facingRight && movement.x < 0)
			Flip ();
		else if(!facingRight && movement.x > 0)
			Flip ();

		//boundaries control
		Vector3 playerSize = GetComponent<SpriteRenderer> ().sprite.bounds.size;
		float viewWidth = (Screen.width * Camera.main.orthographicSize) / Screen.height;
		float relWidth = (playerSize.x / 2) / viewWidth / 2;
		Vector3 viewPos = Camera.main.WorldToViewportPoint (this.transform.position);
		viewPos.x = Mathf.Clamp (viewPos.x, 0+relWidth, 1-relWidth);
		this.transform.position = Camera.main.ViewportToWorldPoint (viewPos);
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
		//accelerometer control
		float x = Input.acceleration.x;
		rigidbody2D.transform.Translate(x*0.4f,0,0);
		if(facingRight && x < 0)
			Flip ();
		else if(!facingRight && x > 0)
			Flip ();

	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ObjScript obj = otherCollider.gameObject.GetComponent<ObjScript>();
		if(obj != null)
		{
			if(obj.isObstacle)
			{
				Application.LoadLevel (2);
				Destroy(gameObject);
			}
		}
			
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
