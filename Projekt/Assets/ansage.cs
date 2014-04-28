using UnityEngine;
using System.Collections;

public class ansage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			GetComponent<TextMesh>().text = "Auto kommt";
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			GetComponent<TextMesh>().text = "Auto raus";
		}
	
	}
}
