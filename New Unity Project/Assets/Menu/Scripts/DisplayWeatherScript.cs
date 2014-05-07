using UnityEngine;
using System.Collections;
using SimpleJSON;

public class DisplayWeatherScript : MonoBehaviour 
{
	float width;
	float height;
	
	public string currentIP;
	public string currentCity;
	public float Fahrenheit;
	public float Celsius;
	public string temp;
	public string retrievedCoordinates;
	public string retrievedCoordinates2;
	public string retrievedCity;
	public int conditionID;
	public string conditionName;
	
	// Use this for initialization
	void Start ()
	{
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		StartCoroutine(SendRequest());
	}
	
	IEnumerator SendRequest()
	{
		//opens a connection and gets the player IP, City, Country
		Network.Connect("http://google.com");
		currentIP = Network.player.externalIP;
		Network.Disconnect();
		
		WWW cityRequest = new WWW("http://www.geoplugin.net/json.gp?ip=" + currentIP); //get our location info
        yield return cityRequest;
		
		if (cityRequest.error == null || cityRequest.error == "")
		{
			var N = JSON.Parse(cityRequest.text);
			currentCity = N["geoplugin_city"].Value;
		}
		else
        {
            Debug.Log("WWW error: " + cityRequest.error);
        }
		
		//get the current weather
        WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?q=" + currentCity); 
		//search by lat and long api.openweathermap.org/data/2.5/weather?lat=??&lon=??
        yield return request;
		
		if (request.error == null || request.error == "")
		{
			var N = JSON.Parse(request.text);
			
			temp = N["main"]["temp"].Value; //get the temperature
            float tempTemp; //variable to hold the parsed temperature
            float.TryParse(temp, out tempTemp); //parse the temperature
			Fahrenheit = Mathf.Round((tempTemp - 273.0f)*(float)1.8)+32; //Fahrenheit 
            Celsius  = Mathf.Round((tempTemp - 273.0f)*10)/10; //Celsius 
		}
		else
        {
            Debug.Log("WWW error: " + request.error);
        }
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width / 2.0f , Screen.height/5.5f, width, height),  Celsius.ToString() + "C");
		GUI.Label(new Rect(Screen.width / 3.5f , Screen.height/5.5f, width, height), Fahrenheit.ToString() + "F");
    }
}
