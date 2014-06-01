using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {
	// Use this for initialization

	public float delay = 0;
	void Start () {	

	}
	
	// Update is called once per frame
	void Update () {
		playAudio ();
	}

	IEnumerator  playAudio(){
		audio.Play();
		yield return new WaitForSeconds (delay);
	}
}
	