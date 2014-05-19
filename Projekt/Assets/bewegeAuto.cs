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
						gameObject.transform.Translate (1, 0, 0);
						Debug.Log ("gerade aus");
						//GameObject.Find("Ampel");

				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
						gameObject.transform.Translate (-1, 0, 0);
						Debug.Log ("rückwärts");
							if (Input.GetKeyDown (KeyCode.RightArrow)) {
									gameObject.transform.Translate (-1, 0, 0);
									Debug.Log ("rückwärts");
									}
						
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
						gameObject.transform.Rotate(0, 8, 0);
						gameObject.transform.Translate (1, 0, 0);
						Debug.Log("rechts");
						
						
				}
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						gameObject.transform.Rotate (0, -8, 0);
						gameObject.transform.Translate (1, 0, 0);
						Debug.Log ("rechts");
				}

		}
}