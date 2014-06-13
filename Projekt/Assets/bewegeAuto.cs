using UnityEngine;
using System.Collections;

//Bearbeiter: Hülya und Ann-Kristin
//Steuerung des Autos

public class bewegeAuto : MonoBehaviour {

	//http://docs.unity3d.com/ScriptReference/Input.GetAxis.html
	
	//Fahrtgeschwindigkeit
	public float speed = 10.0F;
	//Rotationsgeschwindigkeit
	public float rotationSpeed = 100.0F;
	
	
	void Update() {
		//Bei vertikalen Pfeiltasten (oben & unten), bewegt sich das Objekt vorwärts oder rückwärts
		float translation = Input.GetAxis("Vertical") * speed;
		//Bei horizontalen Pfeiltasten (rechts & links), rotiert das Objekt in die entsprechende Richtung
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		//andere Schreibweise: translation = translation * Time.deltaTime;
		//mit der Multiplikation von Time.deltaTime bewegt/rotiert sich das Objekt flüssig in die entsprechende Richtung
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		//Translation zur z-Achse
		transform.Translate(0, 0, translation);
		//Rotation in y-Achse
		transform.Rotate(0, rotation, 0);
	}
}

/*
 * Auto bewegt sich
 * 
	void Start () {
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.z++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.z--;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.x++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.x--;
			this.transform.position = position;
		}
	}*/

/*
	 * 
	 * private float speed = 5f;
	public Transform playergraphic;
	
	void  Update (){
		Movement();
	}
	
	void  Movement (){
		
		//Player object movement
		float horMovement = Input.GetAxisRaw("Horizontal");
		if(horMovement != 0)
		{
			transform.forward = new Vector3(horMovement, 0f, 0f);
		}
		float vertMovement = Input.GetAxisRaw("Vertical");
		if(horMovement != 0 && vertMovement != 0){
			speed = 1.0f;
		}else{
			speed = 1.5f;
		}
		transform.Translate(transform.right * horMovement * Time.deltaTime * speed);
		transform.Translate(transform.forward * vertMovement * Time.deltaTime * speed);
		
		//Player Rotation
		Vector3 moveDirection= new Vector3 (horMovement, 0, vertMovement);  
		if (moveDirection != Vector3.zero){
			Quaternion newRotation = Quaternion.LookRotation(moveDirection);
			playergraphic.transform.rotation = Quaternion.Slerp(playergraphic.transform.rotation, newRotation, Time.deltaTime * 8);
		}
		//Player Animation
		if(moveDirection.magnitude > 0.05f){
			playergraphic.animation.CrossFade("walk", 0.2f);
		}else{
			playergraphic.animation.CrossFade("idle", 0.2f);
		}
	}*/




