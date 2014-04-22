using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI()
	{
		float width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		float height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height/4, width, height), "Start"))
		{
			Application.LoadLevel("Stage1");
		}
	}
}
