using UnityEngine;
using System.Collections;

public class bewegen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			gameObject.transform.Translate(2, 2, 2);
			gameObject.renderer.material.color = Color.red;
			Debug.Log("rechts");
			GameObject.Find("Ampel").;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			gameObject.transform.Translate(-2, -2, -2);
			gameObject.renderer.material.color = Color.green;
			Debug.Log("links");
		}
	}
}
