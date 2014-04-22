using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI()
	{

		if(GUI.Button (new Rect(Screen.width / 2 - 30, Screen.height/4, 60, 30), "Start"))
		{
			Application.LoadLevel("Stage1");
		}
	}
}
