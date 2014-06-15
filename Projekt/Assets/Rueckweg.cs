using UnityEngine;
using System.Collections;
//Bearbeiter: Hülya und Ann-Kristin
//Drone kehrt zurück zur Basis/Station
//Dieses Script wird aktiviert, wenn aktives Auto geparkt hat
public class Rueckweg : MonoBehaviour {

	private Database manage = new Database ();
	public GameObject QuadCopter;
	public GameObject way1;
	public GameObject way2;
	public GameObject way3;
	public GameObject way4;
	public State state;
	public float time;
	public float rotationSpeed;
	public float moveSpeed;
	public float speed = 5;
	public float myTimer = 10;
	public int randomNumber;
	public enum State{
		Idle,
		Way1,
		Way2,
		Way3,
		Way4
	}
	public int a;
	public int b;
	public float c;
	public int d;
	public int e;
	public int g;
	public int h;
	public int j;
	public int k;
	Vector3 dronpos;
	float distance3;
	float distance2;
	float distance1;
	float distance;
	
	// Use this for initialization
	void Start () {
		/*if (way4 == null) {
		//	way4=way3;
		//}
		else*/
		
		//c=Flughöhe
		c = 1f;
		
		a = 10;
		b = 10;
		d = 20;
		e = 20;
		g = 5;
		h = 5;
		j = 40;
		k = 30;
		//way1.transform.position = new Vector3 (a,c,b);
		//way2.transform.position = new Vector3 (d,c,e);
		//way3.transform.position = new Vector3 (g,c,h);
		//way4.transform.position = new Vector3 (j,c,k);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		
		
		
		if (3==manage.getStatusDrone(QuadCopter.name)){
			
			switch (state) {
			case State.Idle:
				Idle ();
				break;
			case State.Way1:
				Way1 ();
				break;
			case State.Way2:
				Way2 ();
				break;
			case State.Way3:
				Way3 ();
				break;
			case State.Way4:
				Way4 ();
				break;
			}}
	}
	
	
	
	public void Idle(){
		state = State.Way1;  
	}
	
	public void Way1(){
		//Distanz zwischen zwei Objekte messen und bei einem bestimmten Abstand die Methode weiter ausführen
		
		//aktuelle Position der Drohne
		//stoppt die Drohne, soll die Drohne an dieser Stelle weiterfliegen
		dronpos = this.drohnepos ();
		
		//Distanz zwischen der Drohne und dem Waypoint bestimmen
		distance = Vector3.Distance (dronpos, way1.transform.position);
		Debug.Log ("Way1   " +distance);
		QuadCopter.transform.rotation = Quaternion.Slerp (QuadCopter.transform.rotation,new Quaternion(0f, Quaternion.LookRotation (way1.transform.position - QuadCopter.transform.position).y,0f,1f), rotationSpeed + Time.deltaTime);
		Debug.Log (QuadCopter.transform.forward);
		QuadCopter.transform.position = Vector3.MoveTowards(QuadCopter.transform.position, way1.transform.position, moveSpeed * Time.deltaTime);
		Debug.Log (QuadCopter.transform.position);
		if (distance < 0.1f) {
			state = State.Way2;
		}
		
	}
	
	public void Way2(){
		
		dronpos = this.drohnepos ();
		
		distance1 = Vector3.Distance (dronpos, way2.transform.position);
		Debug.Log ("WAY2   " +distance1);
		QuadCopter.transform.rotation = Quaternion.Slerp (QuadCopter.transform.rotation,new Quaternion(0f,Quaternion.LookRotation (way2.transform.position - QuadCopter.transform.position).y,0f,1f), rotationSpeed + Time.deltaTime);
		QuadCopter.transform.position = Vector3.MoveTowards(QuadCopter.transform.position, way2.transform.position, moveSpeed * Time.deltaTime);
		if (distance1 < 0.1f){
			state = State.Way3;
		}
	}
	public void Way3(){
		
		dronpos = this.drohnepos ();
		
		distance2 = Vector3.Distance (dronpos, way3.transform.position);
		Debug.Log ("Way3  "  +distance2);
		QuadCopter.transform.rotation = Quaternion.Slerp (QuadCopter.transform.rotation,new Quaternion(0f,Quaternion.LookRotation (way3.transform.position - QuadCopter.transform.position).y,0f,1f), rotationSpeed + Time.deltaTime);
		QuadCopter.transform.position = Vector3.MoveTowards(QuadCopter.transform.position, way3.transform.position, moveSpeed * Time.deltaTime);
		
		if (distance2 < 0.1f){
			state = State.Way4;
			
		}
	}
	public void Way4(){
		
		dronpos = this.drohnepos ();
		
		distance3 = Vector3.Distance (dronpos, way4.transform.position);
		Debug.Log ("Way4  " +distance3);
		QuadCopter.transform.rotation = Quaternion.Slerp (QuadCopter.transform.rotation,new Quaternion(0f,Quaternion.LookRotation (way4.transform.position - QuadCopter.transform.position).y,0f,1f), rotationSpeed + Time.deltaTime);
		QuadCopter.transform.position = Vector3.MoveTowards(QuadCopter.transform.position, way4.transform.position, moveSpeed * Time.deltaTime);
		
		if (distance3 < 0.1f){
			manage.UpdateStatusDrone ("QuadCopter", "0");
			state = State.Idle;
			
			
		}
	}
	
	/*public Transform other;
		void Distan() {
			if (other) {
				float dist = Vector3.Distance(other.position, transform.position);
				print("Distance to other: " + dist);
			}
		}*/
	
	//Aktuelle Position der Drohne erhalten
	public Vector3 drohnepos() {
		
		return QuadCopter.transform.position;
		
	}
}