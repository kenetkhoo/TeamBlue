using UnityEngine;
using System.Collections;
using SimpleJSON;

public class DisplayWeatherScript : MonoBehaviour 
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
	public string retrievedCity;
	public int weatherID;
	public string conditionName;
		
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
			//print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		}
		Input.location.Stop();
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
		StartCoroutine(SendRequest());
	}
	
	IEnumerator SendRequest()
	{
	/*
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
	*/
		

		//get the current weather; search by lat and lon api.openweathermap.org/data/2.5/weather?lat=??&lon=??
		WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon); 
        //WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?q=" + currentCity); 
        yield return request;
		
		if (request.error == null || request.error == "")
		{
			var N = JSON.Parse(request.text);
			retrievedCoordinates = N["coord"]["lon"].Value; //longitude
			retrievedCoordinates2 = N["coord"]["lat"].Value; //longitude
			retrievedCitys = N["name"].Value; //get the city
			print (retrievedCitys);
			temp = N["main"]["temp"].Value; //get the temperature
            float tempTemp; //variable to hold the parsed temperature
            float.TryParse(temp, out tempTemp); //parse the temperature
			Fahrenheit = Mathf.Round((tempTemp - 273.0f)*(float)1.8)+32; //Fahrenheit 
            Celsius  = Mathf.Round((tempTemp - 273.0f)*10)/10; //Celsius 
		}
		else
        {
            Debug.Log("Cannot get GPS location: " + request.error);
        }
	}
	
	void OnGUI()
	{
	//	GUI.Label(new Rect(Screen.width / 2.0f , Screen.height/5.5f, width, height), Celsius.ToString() + "C");
		GUI.Label(new Rect(Screen.width / 6.5f , Screen.height/5.5f, width, height), Fahrenheit.ToString() + "F" + Celsius.ToString() + "C" + " " +retrievedCitys + " " + lon +"lon" + lat+ "lat");
    }
}
