using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	float playerScore = 0;
	float width;
	float height;
	private Vector2 position = new Vector2(50, 50);
	void Start () {
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		position.x = Screen.width / 100;
		position.y = Screen.height / 100;
	}
	
	void Update () {
		playerScore += Time.deltaTime;
	}

	public void IncreaseScore(int amount)
	{
		playerScore += amount;
	}

	void OnGUI()
	{
		GUI.skin.label.fontSize = Mathf.RoundToInt (Screen.height / 25f);
		GUI.contentColor = Color.gray;
		GUI.Label(new Rect(position.x, position.y, width, height), "Score: " + (int) (playerScore * 100));
	}

	void OnDisable()
	{
		PlayerPrefs.SetInt ("Score", (int) (playerScore * 100));
	}
}
