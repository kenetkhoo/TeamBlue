using UnityEngine;
using System.Collections;

public class ChooseWeatherScript : MonoBehaviour {


	float width;
	float height;
	public Texture2D image;
	public AudioClip buttonsound;
	GUIContent content = new GUIContent();
	public GUIStyle customButton;
	// Use this for initialization

	void Start () {
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 12) * Camera.main.pixelHeight) / Screen.height;
		content.image = (Texture2D)image;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		customButton.fontSize = Mathf.RoundToInt (Screen.height / 25f);
		customButton.fixedHeight = height*2.8f;
		customButton.fixedWidth = width;
		if(GUI.Button (new Rect(Screen.width / 30 , Screen.height*1.75f/4.5f, width, height*1.75f), "Sunny" , customButton))
		{

				Application.LoadLevel("SunnyScene");
	
		}
		
		if(GUI.Button (new Rect(Screen.width / 2 , Screen.height*1.75f/4.5f, width, height*1.75f), "Rainy", customButton))
		{

			Application.LoadLevel("RainyScene");
		}

		if(GUI.Button (new Rect(Screen.width / 30 , Screen.height*2.5f/4.5f, width, height*1.75f), "Windy", customButton))
		{
			
			Application.LoadLevel("WindyScene");
		}
		if(GUI.Button (new Rect(Screen.width / 2 , Screen.height*2.5f/4.5f, width, height*1.75f), "Snowy", customButton))
		{

			Application.LoadLevel("SnowyScene");
		}
		

		
		
	}
}
