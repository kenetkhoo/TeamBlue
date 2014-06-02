﻿using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	
	int score = 0;
	float width;
	float height;
	public Texture2D image;
	GUIContent content = new GUIContent();
	public AudioClip buttonsound;
	public GUIStyle customButton;

	void Start () {
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		content.image = (Texture2D)image;
		score = PlayerPrefs.GetInt ("Score");
		calculateHighScore();

	}
	void calculateHighScore()
	{
		int currentScore = score;
		int nextScore;
		for( int i = 1; i<= 5;i++)
		{
			nextScore = PlayerPrefs.GetInt(""+i,0);
			if(currentScore > nextScore )
			{
				PlayerPrefs.SetInt(""+i,currentScore);
				currentScore = nextScore;
			}
		}
	}
	void OnGUI()
	{
		GUI.skin.button.fontSize = Mathf.RoundToInt (Screen.height / 20f);
		GUI.skin.label.fontSize = Mathf.RoundToInt (Screen.height / 22f);
		GUI.contentColor = Color.black;
		GUI.Label (new Rect (Screen.width / 4 , Screen.height/10, width*2, height), "GAME OVER");
		
		GUI.Label (new Rect (Screen.width / 4, Screen.height/6, width, height), "Score: " + score);

		customButton.fontSize = Mathf.RoundToInt (Screen.height / 25f);
		customButton.fixedHeight = height*2.8f;
		customButton.fixedWidth = width;
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height*1/4.5f, width, height*1.75f), "Retry", customButton))
		{
			audio.Stop();
			audio.clip = buttonsound;
			audio.Play();
			int weatherID = PlayerPrefs.GetInt("WID");
			/* display weather scene in game depending on weather code **/
			
			if(weatherID >= 200 && weatherID <= 523){
				Application.LoadLevel("RainyScene");
			}
			else if (weatherID >= 600 && weatherID <= 621){
				Application.LoadLevel("SnowyScene");
			}
			else if (weatherID >= 953 && weatherID <= 962){
				Application.LoadLevel ("WindyScene");
			}
			else{
				Application.LoadLevel("SunnyScene");
			}
		}
		
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height*1.75f/4.5f, width, height*1.75f), "Main Menu", customButton))
		{
			audio.Stop ();
			audio.clip = buttonsound;
			audio.Play();
			Application.LoadLevel("TitleScene");
		}
	}
}

