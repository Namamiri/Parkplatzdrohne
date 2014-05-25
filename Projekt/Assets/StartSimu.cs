using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartSimu : MonoBehaviour {
	List<GameObject> Cars = new List<GameObject>();
	// Use this for initialization
	void Start () {
		Database datenbank = new Database ();
		datenbank.createDatabase ();
		datenbank.filltableParkplatz ();
		//this.Cars.Add(CreateCar.fromPrefab ());
		this.Cars.Add(CreateCar.fromfbx ());
		this.Cars.Add (CreateCar.onstartpoint());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
