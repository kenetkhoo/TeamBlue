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
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		content.image = (Texture2D)image;
	}
		
	void OnGUI(){
		customButton.fontSize = Mathf.RoundToInt (Screen.height / 30f);
		customButton.fixedHeight = height*5;
		customButton.fixedWidth = width;
		if(GUI.Button (new Rect(Screen.width / 17.7f , Screen.height/16.5f, width, height*4), "Back To Menu", customButton))
		{
			Application.LoadLevel("TitleScene");
		}
	}
}
