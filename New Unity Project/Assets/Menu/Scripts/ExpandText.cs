using UnityEngine;
using System.Collections;

public class ExpandText : MonoBehaviour {
	private float scale;
	public float maxScale;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(scale <= maxScale)
			scale = scale + 0.025f;
		if (scale < maxScale)
			transform.localScale += new Vector3(0.025f,0.025f,0);
	}
}
