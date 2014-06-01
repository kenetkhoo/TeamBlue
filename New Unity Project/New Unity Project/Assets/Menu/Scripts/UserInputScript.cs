using UnityEngine;
using System.Collections;

public class UserInputScript : MonoBehaviour {

	float width;
	float height;

	public string cityName = "Enter a city";
	
	void Start () {


	}
	
	void Update () {

	}
	
	void OnGUI() {
		cityName  = GUI.TextField (new Rect (Screen.width / 5.0f, Screen.height / 2.9f, 200, 30), cityName);
		PlayerPrefs.SetString("cityName", cityName);
		if (Event.current.Equals (Event.KeyboardEvent ("return"))) {
			Application.LoadLevel("WeatherScene");
		}
	}
	
	
}
