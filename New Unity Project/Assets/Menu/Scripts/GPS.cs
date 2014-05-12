using UnityEngine;
using System.Collections;

public class GPS : MonoBehaviour {
	float width;
	float height;
	public float lat;
	public float lon;
	
	IEnumerator Start() {
		width = ((Screen.width / 2) * Camera.main.pixelWidth) / Screen.width;
		height =  ((Screen.height/ 10) * Camera.main.pixelHeight) / Screen.height;
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
	}
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width / 2.0f , Screen.height/5.5f, width, height), lat + "C");
		GUI.Label(new Rect(Screen.width / 3.5f , Screen.height/5.5f, width, height), lon +"F");
		
		//GUI.Label(new Rect(Screen.width / 2.0f , Screen.height/5.5f, width, height), Input.location.lastData.latitude + "C");
		//GUI.Label(new Rect(Screen.width / 3.5f , Screen.height/5.5f, width, height), Input.location.lastData.longitude+"F");
	}
}
