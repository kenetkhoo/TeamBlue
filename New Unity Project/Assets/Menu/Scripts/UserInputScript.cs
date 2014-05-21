using UnityEngine;
using System.Collections;

public class UserInputScript : MonoBehaviour {

	float width;
	float height;

	public string cityName = "";
	public TouchScreenKeyboard keyboard;
	
	void Start () {
		keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, false, false, false, "" );
		keyboard.active = false;
	}
	
	void Update () {

	}
	
	void OnGUI() {	
		cityName = GUI.TextField(new Rect(Screen.width / 5.0f , Screen.height/2.0f, 200, 30), " Enter city name");
		keyboard.active = true;
		keyboard = TouchScreenKeyboard.Open(cityName, TouchScreenKeyboardType.Default, true, false, false, false, "");
		
		if(keyboard.done){
			cityName = keyboard.text;
			keyboard.active = false;
		}
	}
	
	
}
