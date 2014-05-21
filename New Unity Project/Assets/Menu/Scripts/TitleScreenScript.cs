using UnityEngine;
using System.Collections;
using SimpleJSON;

public class TitleScreenScript : MonoBehaviour {
	public float lon;
	public float lat;
	int weatherID = 0;
	float width;
	float height;
	public Texture2D image;
	public AudioClip buttonsound;
	GUIContent content = new GUIContent();
	public GUIStyle customButton;
	// Use this for initialization
	IEnumerator Start () {
		
		
		
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 12) * Camera.main.pixelHeight) / Screen.height;
		content.image = (Texture2D)image;
		
		
		if (!Input.location.isEnabledByUser)
			yield break;
		Input.location.Start (1, 1);
		
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds (1);
			maxWait--;
		}
		if (maxWait < 1) {
			print ("Timed out");
			yield break;
		}
		if (Input.location.status == LocationServiceStatus.Failed) {
			print ("Unable to determine device location");
			yield break;
		} else {
			
			lat = Input.location.lastData.latitude;
			lon = Input.location.lastData.longitude; 
		}
		Input.location.Stop ();
		WWW request = new WWW ("http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon); 
		yield return request;
		
		if (request.error == null || request.error == "") {
			var N = JSON.Parse (request.text);
			int.TryParse(N["weather"][0]["id"].Value, out weatherID); //weather ID
		}
		
	}
	
	// Update is called once per frame
	void OnGUI()
	{
		string scene = "SunnyScene";
		customButton.fontSize = Mathf.RoundToInt (Screen.height / 25f);
		customButton.fixedHeight = height*2.8f;
		customButton.fixedWidth = width;
		if(GUI.Button (new Rect(Screen.width / 4 , Screen.height*1/4.5f, width, height*1.75f), "Start" , customButton))
		{
			audio.clip = buttonsound;
			audio.Play();
			weatherID = PlayerPrefs.GetInt("WID");
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