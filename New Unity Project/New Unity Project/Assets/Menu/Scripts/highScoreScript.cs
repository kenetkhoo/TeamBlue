using UnityEngine;
using System.Collections;

public class highScoreScript : MonoBehaviour {
	public int highscore;
	// Use this for initialization
	void Start () {
		TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
		t.text = PlayerPrefs.GetInt (""+highscore,0).ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
