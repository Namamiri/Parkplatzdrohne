using UnityEngine;
using System.Collections;

public class KeyEvent : MonoBehaviour {
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space))
			print("space key was pressed");
		
	}
}
