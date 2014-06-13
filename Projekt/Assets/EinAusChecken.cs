using UnityEngine;
using System.Collections;

// Globale Steuerung für EIn und Auschecken der Autos von hier wird alles gestartet

public class EinAusChecken : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Erzeugt ein neues Auto indem er eine Funktion in Create Car aufruft
		if (Input.GetKeyDown (KeyCode.N)) {
			Debug.Log("Neues Auto wurde Gedrückt");
			Debug.Log(CreateCar.onstartpoint());
			WayPointControl.UmstellenderWayPoints();
		}
		// Entfernt Auto indem er eine Funktion in Create Car aufruft
		if (Input.GetKeyDown (KeyCode.Minus)) {
			Debug.Log ("Auto wurde entfernt");
			CreateCar.KillCar();
		}
		if (Input. GetKeyDown (KeyCode.P)){
			CreateCar.ParkAuto();
			}
	}
}
