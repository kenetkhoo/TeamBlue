using UnityEngine;
using System.Collections;

public class rotateCloud : MonoBehaviour {
	public int rotationSpeed = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.back*Time.deltaTime*rotationSpeed);
	}
}
