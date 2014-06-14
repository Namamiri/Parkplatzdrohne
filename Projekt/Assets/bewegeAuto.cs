using UnityEngine;
using System.Collections;

//Bearbeiter: Hülya und Ann-Kristin
//Steuerung des Autos

public class bewegeAuto : MonoBehaviour {

	//http://docs.unity3d.com/ScriptReference/Input.GetAxis.html
	Database manage = new Database ();
	//Fahrtgeschwindigkeit
	public float speed = 1.0F;
	//Rotationsgeschwindigkeit
	public float rotationSpeed = 100.0F;

	float translation;
	float rotation;
	Vector3 ziel=new Vector3(-10.00448f,-0.01464844f,-10.67066f);
	void Update() {


		if (1 == manage.stateofcar (gameObject.name)) {
						//Bei vertikalen Pfeiltasten (oben & unten), bewegt sich das Objekt vorwärts oder rückwärts
						translation = Input.GetAxis ("Vertical") * speed;
						//Bei horizontalen Pfeiltasten (rechts & links), rotiert das Objekt in die entsprechende Richtung
						rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
						//andere Schreibweise: translation = translation * Time.deltaTime;
						//mit der Multiplikation von Time.deltaTime bewegt/rotiert sich das Objekt flüssig in die entsprechende Richtung
						translation *= Time.deltaTime;
						rotation *= Time.deltaTime;
						//Translation zur z-Achse
						transform.Translate (translation, 0, 0);
						//Rotation in y-Achse
						transform.Rotate (0, rotation, 0);
		} else if (3 == manage.stateofcar (gameObject.name)) {
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, ziel, 1 * Time.deltaTime);
			if (Vector3.Distance(gameObject.transform.position,ziel)<0.2f){
				manage.deletecar(gameObject.name);
				DestroyImmediate(gameObject);
			}
		}
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




