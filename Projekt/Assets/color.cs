using UnityEngine;
using System.Collections;

public class color : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			gameObject.renderer.material.color = Color.red;
			print("hallo");
				}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			gameObject.renderer.material.color = Color.green;
		}
	}
}
