using UnityEngine;
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
	public string image; 
	
	
		
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
		StartCoroutine(SendRequest());
	}
	
	IEnumerator SendRequest(){
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
			Description = N["weather"][0]["description"].Value; //weather's description 
			image = N["weather"][0]["icon"].Value; 
		}
		else{
            Debug.Log("Cannot get GPS location: " + request.error);
        }
		
	}

	void OnGUI(){
		var myStyl = new GUIStyle();
		myStyl.fontSize = 20;
		GUI.contentColor = Color.black; 
		GUI.Label(new Rect(Screen.width / 5.5f , Screen.height/8.7f, width, height*6), "\n" + Fahrenheit.ToString() + "F" + " " + Celsius.ToString() + "C" 
				  + "\n" + Description.ToString() + "\n" + City.ToString()+ ", " + Country.ToString() +"\n" + lon +" lon" + " " + lat+ " lat", myStyl);
    }
}
