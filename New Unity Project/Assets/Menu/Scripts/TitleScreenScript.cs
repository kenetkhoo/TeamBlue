using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	float width;
	float height;
	public Texture2D image;
	GUIContent content = new GUIContent();
	public GUIStyle customButton;
	// Use this for initialization
	void Start () {
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 12) * Camera.main.pixelHeight) / Screen.height;
		content.image = (Texture2D)image;
		
		
	}
	
	// Update is called once per frame
	void OnGUI()
	{
		customButton.fontSize = Mathf.RoundToInt (Screen.height / 20f);
		customButton.fixedHeight = height*2;
		customButton.fixedWidth = width;
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height/4, width, height), "Start", customButton))
		{
			Application.LoadLevel("GameScene");
		}
		
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height/2.5f, width, height), "High Score", customButton))
		{
			Application.LoadLevel("HighScoreScene");
		}
		
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height/1.8f, width, height), "Weather", customButton))
		{
			Application.LoadLevel("WeatherScene");
		}

		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height/1.4f, width, height), "Settings", customButton))
		{
			Application.LoadLevel("SettingsScene");
		}

		if(GUI.Button (new Rect(Screen.width / 16 , Screen.height/1.1f , width/3, height), "TW"))
		{
			
		}
		
		if(GUI.Button (new Rect(Screen.width / 3.8f  , Screen.height/1.1f , width/3, height), "FB"))
		{
			
		}
	}
	
}