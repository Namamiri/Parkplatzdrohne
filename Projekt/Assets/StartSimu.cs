using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartSimu : MonoBehaviour {
	List<GameObject> Cars = new List<GameObject>();
	// Use this for initialization
	void Start () {

		Cars.Add(CreateCar.fromPrefab ());
		Database datenbank = new Database ();;
		datenbank.Start ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
