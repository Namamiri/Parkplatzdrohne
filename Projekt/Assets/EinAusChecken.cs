using UnityEngine;
using System.Collections;

public class EinAusChecken : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N)) {
			Debug.Log("Neues Auto wurde Gedrückt");
		}
		if (Input.GetKeyDown (KeyCode.Minus)) {
			Debug.Log ("Auto wurde entfernt");
			
		}
	}
}
