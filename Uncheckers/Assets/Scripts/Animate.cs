using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("COmplete");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.C)) 
		{
			gameObject.GetComponent<Animation> ().Play("Flip");
		}
	}
}
