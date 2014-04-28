using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartSimu : MonoBehaviour {
	List<GameObject> Cars = new List<GameObject>();
	// Use this for initialization
	void Start () {
		Database datenbank = new Database ();
		datenbank.createDatabase ();
		this.Cars.Add(CreateCar.fromPrefab ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
