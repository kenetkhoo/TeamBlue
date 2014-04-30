using UnityEngine;
using System.Collections;

public class WeatherScript : MonoBehaviour {
	
	
	
	WWW weatherWebsite;
	bool Done = true;
	string urlSave;
	
	// Use this for initialization
	void Start () {
		string loc = "Pomona";
		string url = "http://api.worldweatheronline.com/free/v1/weather.ashx?q=" + loc + "&format=xml&num_of_days=1&key=u247zy5k7n3bktwyfyqgesfq";
		weatherWebsite = new WWW (url);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(weatherWebsite.isDone && Done)
		{
			urlSave = weatherWebsite.text;
			print (urlSave);
			Done = false;
		}
		
	}
}
