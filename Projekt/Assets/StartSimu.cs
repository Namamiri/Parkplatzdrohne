using UnityEngine;
using System.Collections;

public class StartSimu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Database datenbank = new Database ();;
		datenbank.Start ();
		KeyEvent key = new KeyEvent ();


	}


	// Update is called once per frame
	void Update () {

	}
}
