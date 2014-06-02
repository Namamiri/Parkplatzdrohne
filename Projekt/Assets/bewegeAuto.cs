using UnityEngine;
using System.Collections;

public class bewegeAuto : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Auto Steuerung
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
						gameObject.transform.Translate (0.1f, 0f, 0f);
						Debug.Log ("gerade aus");
						//GameObject.Find("Ampel");

				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
						gameObject.transform.Translate (-0.1f, 0f, 0f);
						Debug.Log ("rückwärts");
							if (Input.GetKeyDown (KeyCode.RightArrow)) {
									gameObject.transform.Translate (-0.1f, 0f, 0f);
									Debug.Log ("rückwärts");
									}
						
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
						gameObject.transform.Rotate(0f, 8f, 0f);
						gameObject.transform.Translate (0.1f, 0f, 0f);
						Debug.Log("rechts");
						
						
				}
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						gameObject.transform.Rotate (0f, -8f, 0f);
						gameObject.transform.Translate (0.1f, 0f, 0f);
						Debug.Log ("rechts");
				}

		}
}