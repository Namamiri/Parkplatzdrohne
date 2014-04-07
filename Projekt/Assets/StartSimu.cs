using UnityEngine;
using System.Collections;

public class StartSimu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Database datenbank = new Database ();;
		datenbank.Start ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
