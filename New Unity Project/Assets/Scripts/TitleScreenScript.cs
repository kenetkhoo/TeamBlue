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

		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height/4, width, height), content))
		{
			Application.LoadLevel("Stage1");
		}
	}
}
