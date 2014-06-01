﻿using UnityEngine;
using System.Collections;
using SimpleJSON;

public class WeatherScript : MonoBehaviour 
{
	float width;
	float height;
	
	public float lon;
	public float lat;
	public string retrievedCoordinates;
	public string retrievedCoordinates2;
	public string retrievedCitys;
	public string currentIP;
	public string currentCity;
	public float Fahrenheit;
	public float Celsius;
	public string temp;
	public string City;
	public int weatherID;
	public string Description;
	public string Country;
	public new string cityName="";
	
	
	// Use this for initialization
	IEnumerator Start ()
	{
		if (!Input.location.isEnabledByUser)
			yield break;
		Input.location.Start(1,1);
		
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		if (maxWait < 1) {
			print("Timed out");
			yield break;
		}
		if (Input.location.status == LocationServiceStatus.Failed) {
			print("Unable to determine device location");
			yield break;
		} else{
			lat = Input.location.lastData.latitude;
			lon = Input.location.lastData.longitude; 
			print("Location: " + lat + " " + lon + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		}
		Input.location.Stop();
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		name = PlayerPrefs.GetString("cityName");
		StartCoroutine(SendRequest());
	}
	
	IEnumerator SendRequest()
	{
		if(cityName =="")
		{//uses the phone's GPS to retrieve the information
			WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon); 
			yield return request;
			
			if (request.error == null || request.error == ""){
				var N = JSON.Parse(request.text);
				retrievedCoordinates = N["coord"]["lon"].Value; //longitude
				retrievedCoordinates2 = N["coord"]["lat"].Value; //longitude
				City = N["name"].Value; //get the city
				Country = N["sys"]["country"].Value; //get the country
				print (City);
				temp = N["main"]["temp"].Value; //get the temperature
				float tempTemp; //variable to hold the parsed temperature
				float.TryParse(temp, out tempTemp); //parse the temperature
				Fahrenheit = Mathf.Round((tempTemp - 273.0f)*(float)1.8)+32; //Fahrenheit 
				Celsius  = Mathf.Round((tempTemp - 273.0f)*10)/10; //Celsius 
				int.TryParse(N["weather"][0]["id"].Value, out weatherID); //weather ID
				PlayerPrefs.SetInt("WID",weatherID);
				Description = N["weather"][0]["description"].Value; //weather's description 
			}
		}
		else if (cityName!= "")
		{ //uses the user's input to retrieve the information 
			WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?q=" + cityName); 
			yield return request;

			if (request.error == null || request.error == ""){
				var N = JSON.Parse(request.text);
				retrievedCoordinates = N["coord"]["lon"].Value; //longitude
				retrievedCoordinates2 = N["coord"]["lat"].Value; //longitude
				City = N["name"].Value; //get the city
				Country = N["sys"]["country"].Value; //get the country
				print (City);
				temp = N["main"]["temp"].Value; //get the temperature
				float tempTemp; //variable to hold the parsed temperature
				float.TryParse(temp, out tempTemp); //parse the temperature
				Fahrenheit = Mathf.Round((tempTemp - 273.0f)*(float)1.8)+32; //Fahrenheit 
				Celsius  = Mathf.Round((tempTemp - 273.0f)*10)/10; //Celsius 
				int.TryParse(N["weather"][0]["id"].Value, out weatherID); //weather ID
				PlayerPrefs.SetInt("WID",weatherID);
				Description = N["weather"][0]["description"].Value; //weather's description 
			}
		}
		else
		{
			//default scene  
			Application.LoadLevel("SunnyScene");
		}
	}
	
	void OnGUI()
	{
		var myStyl = new GUIStyle();
		myStyl.fontSize = Mathf.RoundToInt (Screen.height / 25f);
		GUI.skin.button.fontSize = Mathf.RoundToInt (Screen.height / 30f);
		GUI.contentColor = Color.black; 
		GUI.Box(new Rect(Screen.width / 4.5f , Screen.height/5.5f, width, height*3), "Weather");
		GUI.Label(new Rect(Screen.width / 3.2f , Screen.height/4.5f, width, height), "\n" + Fahrenheit.ToString() + "F" + " " + Celsius.ToString() + "C" 
		          + "\n" + Description.ToString() + "\n" + City.ToString(), myStyl);
		cityName  = GUI.TextField (new Rect (Screen.width / 5.0f, Screen.height / 1.9f,Screen.width/2.0f, Screen.height/15f), cityName);
		//for computer
		if ((Event.current.keyCode == KeyCode.Return )) {
			StartCoroutine(SendRequest());
		}
		//for phones
		if(GUI.Button (new Rect(Screen.width / 1.25f, Screen.height / 1.9f, Screen.width/9f,Screen.height/15f), "OK"))
		{
			StartCoroutine(SendRequest());
		}
	}
}
