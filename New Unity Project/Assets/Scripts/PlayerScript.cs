using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour {

	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(50, 50);

	// 2 - Store the movement;
	private Vector2 movement;

	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis ("Horizontal");

		// 4 - Movement per direction
		movement = new Vector2 (
			speed.x * inputX,
			0);
	}

	void FixedUpdate()
	{
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ObjScript obj = otherCollider.gameObject.GetComponent<ObjScript>();
		if(obj != null)
		{
			if(obj.isObstacle)
			{
				Destroy(gameObject);
			}
		}
			
	}
}
