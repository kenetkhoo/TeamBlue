using UnityEngine;
using System.Collections;

public class ExpandText : MonoBehaviour {
	public float scale;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(scale <= 1.0f)
			scale = scale + 0.025f;
		if (scale < 1.0f)
			transform.localScale += new Vector3(0.025f,0.025f,0);
	}
}
