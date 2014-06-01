using UnityEngine;
using System.Collections;

public class BackToMenuScript : MonoBehaviour {
	float width;
	float height;
	public Texture2D image;
	GUIContent content = new GUIContent();
	public GUIStyle customButton;

	void Start () 
	{
		width = ((Screen.width / 4) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 12) * Camera.main.pixelHeight) / Screen.height;
		content.image = (Texture2D)image;
	}
		
	void OnGUI(){
		customButton.fontSize = Mathf.RoundToInt (Screen.height / 2f);
		customButton.fixedHeight = height*2;
		customButton.fixedWidth = width;
		//GUI.backgroundColor = Color.clear;
		if(GUI.Button (new Rect(Screen.width /16.5f, Screen.height/20.5f, width, height), content))
		{
			Application.LoadLevel("TitleScene");
		}
	}
}

//if(GUI.Button (new Rect(Screen.width / 2f , Screen.height/2f, width, height*3), "back", customButton))