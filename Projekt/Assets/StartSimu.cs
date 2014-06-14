//fertig Kommtentiert
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Dieser Script Startet Alles
// Reinigt die Datenbank und füllt den Parkplatz mit zufälligen Autos
public class StartSimu : MonoBehaviour {
	//List<GameObject> Cars = new List<GameObject>();
	// Use this for initialization
	void Start () {

		Database datenbank = new Database ();
		//datenbank.createDatabase ();
		//datenbank.filltableParkplatz ();
		//datenbank.fillTypPunkt ();
		//datenbank.filltableRoutenPunkte();
		//datenbank.filltableRoute ();
		datenbank.fillTableDronen ();
		datenbank.allesaufanfang ();
		//this.Cars.Add(CreateCar.fromPrefab ());
		//this.Cars.Add(CreateCar.fromfbx ());
		//this.Cars.Add (CreateCar.onstartpoint ());
		CreateCar.randomfill ();
		//TypPunkte typenPunkte = new TypPunkte ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
