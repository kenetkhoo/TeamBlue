using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	int score = 0;
	float width;
	float height;
	public Texture2D image;
	GUIContent content = new GUIContent();
	void Start () {
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		content.image = (Texture2D)image;
		score = PlayerPrefs.GetInt ("Score");
	}

	void OnGUI()
	{
		GUI.skin.button.fontSize = Mathf.RoundToInt (Screen.height / 20f);
		GUI.skin.label.fontSize = Mathf.RoundToInt (Screen.height / 22f);
		GUI.Label (new Rect (Screen.width / 4 , Screen.height/10, width*2, height), "GAME OVER");

		GUI.Label (new Rect (Screen.width / 4, Screen.height/6, width, height), "Score: " + score);
		if(GUI.Button (new Rect(Screen.width / 4, Screen.height/4, width, height), content))
		{
			Application.LoadLevel("SunnyScene");
		}
		if(GUI.Button (new Rect(Screen.width / 4, Screen.height/2.5f, width, height), "Menu"))
		{
			Application.LoadLevel("TitleScene");
		}
	}
}
