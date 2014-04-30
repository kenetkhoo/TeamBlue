using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	float width;
	float height;
	public Texture2D image;
	GUIContent content = new GUIContent();
	// Use this for initialization
	void Start () {
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		content.image = (Texture2D)image;

	
	}
	
	// Update is called once per frame
	void OnGUI()
	{
		GUI.skin.button.fontSize = Mathf.RoundToInt (Screen.height / 20f);
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height/4, width, height), content))
		{
			Application.LoadLevel("Stage1");
		}
		
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height/2.5f, width, height), "High Score"))
		{
			Application.LoadLevel("Stage1");
			//change later to correct stage
		}
		
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height/1.8f, width, height), "Weather"))
		{
			Application.LoadLevel("Stage1");
			//change later to correct stage
		}
		if(GUI.Button (new Rect(Screen.width / 16 , Screen.height/1.2f , width/3, height), "TW"))
		{
			
		}
		
		if(GUI.Button (new Rect(Screen.width / 3.8f  , Screen.height/1.2f , width/3, height), "FB"))
		{
			
		}
	}

}
