﻿using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	float width;
	float height;
	public Texture2D image;
	public AudioClip buttonsound;
	GUIContent content = new GUIContent();
	public GUIStyle customButton;
	private WeatherScript id;
		
	// Use this for initialization
	void Start () {
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 12) * Camera.main.pixelHeight) / Screen.height;
		content.image = (Texture2D)image;
	}
	
	// Update is called once per frame
	void OnGUI(){
		id = GetComponent<WeatherScript>();
		
		string scene = "SunnyScene";
		customButton.fontSize = Mathf.RoundToInt (Screen.height / 25f);
		customButton.fixedHeight = height*2.8f;
		customButton.fixedWidth = width;
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height*1/4.5f, width, height*1.75f), "Start", customButton))
		{
			audio.clip = buttonsound;
			audio.Play();
			
			if(id.weatherID > 200 && id.weatherID <= 522 || id.weatherID == 804)
			{ //thunderstorm, drizzle, and rain 
				Application.LoadLevel("RainyScene");
			}
			else if(id.weatherID > 600 && id.weatherID <= 621)
			{ //snow
				Application.LoadLevel("SnowyScene");
			}
			else if (id.weatherID == 905)
			{//windy 
				Application.LoadLevel("WindyScene");
			}
			else
			{//sunny as default 
				Application.LoadLevel(scene);
			}
		}
		
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height*1.75f/4.5f, width, height*1.75f), "High Score", customButton))
		{
			audio.clip = buttonsound;
			audio.Play();
			Application.LoadLevel("HighScoreScene");
		}
		
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height*2.5f/4.5f, width, height*1.75f), "Weather", customButton))
		{
			audio.clip = buttonsound;
			audio.Play();
			Application.LoadLevel("WeatherScene");
		}
		
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height*3.25f/4.5f, width, height*1.75f), "Settings", customButton))
		{
			audio.clip = buttonsound;
			audio.Play();
			Application.LoadLevel("SettingsScene");
		}
		
		/*if(GUI.Button (new Rect(Screen.width / 16 , Screen.height/1.1f , width/3, height), "TW"))
		{
			
		}
		
		if(GUI.Button (new Rect(Screen.width / 3.8f  , Screen.height/1.1f , width/3, height), "FB"))
		{
			
		}*/
	}
	
}