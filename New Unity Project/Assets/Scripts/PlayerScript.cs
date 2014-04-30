using UnityEngine;
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
	private bool touching = false;
	
	void Update()
	{
	}
	
	void FixedUpdate()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis ("Horizontal");
		bool inputY = Input.GetKey ("z");
		// 4 - Movement per direction
		movement = new Vector2 (
			speed.x * inputX,
			0);
		if(facingRight && movement.x < 0)
			Flip ();
		else if(!facingRight && movement.x > 0)
			Flip ();
		//check for tounch
		foreach (Touch touch in Input.touches) {
			if ( touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				touching = true;
		}
		if (Input.touchCount == 0)
			touching = false;
		//boundaries control
		Vector3 playerSize = GetComponent<SpriteRenderer> ().sprite.bounds.size;
		float viewWidth = (Screen.width * Camera.main.orthographicSize) / Screen.height;
		float relWidth = (playerSize.x / 2) / viewWidth / 2;
		float viewHeight = Camera.main.orthographicSize * 2;
		float relHeight = (playerSize.y / 2) / viewHeight / 2;
		Vector3 viewPos = Camera.main.WorldToViewportPoint (this.transform.position);
		viewPos.x = Mathf.Clamp (viewPos.x, 0+relWidth, 1-relWidth);
		viewPos.y = Mathf.Clamp (viewPos.y, 0.1f+relHeight, 0.9f-relHeight);
		this.transform.position = Camera.main.ViewportToWorldPoint (viewPos);
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
		
		//accelerometer control
		float x = Input.acceleration.x;
		float y = 0;
		if (inputY || touching) {
			y = -speed.y * 0.01f;
		} 
		else {
			y = +speed.y * 0.01f;
		}
		rigidbody2D.transform.Translate(x*0.4f,y,0);
		if(facingRight && x < 0)
			Flip ();
		else if(!facingRight && x > 0)
			Flip ();
		//moving up and down
		
		
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

