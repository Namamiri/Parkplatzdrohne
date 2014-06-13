using UnityEngine;
using System.Collections;
// Author Burak Yarali
public class CreateCar : MonoBehaviour {
	// Test nummer Eins ein Object per Code aus einer Prefab laden per Code
	public static GameObject fromPrefab(){
		GameObject Car;
		Debug.Log("Car");
		Car = Instantiate(Resources.Load ("Capsule")) as GameObject;
		Car.transform.Translate (new Vector3 (3, 3, 3));
		return Car;

	}
	// Test #2 Ein Object aus einer FBX laden per Code
	public static GameObject fromfbx(){
		GameObject Car;
		Car = Instantiate(Resources.Load("auto")) as GameObject;
		string naming = "SO";

		naming = naming + System.Convert.ToChar(Random.Range (65, 90));
		naming = naming + System.Convert.ToChar(Random.Range (65, 90));
		naming = naming + Random.Range (25, 999);
		Car.name = naming;
		Car.transform.localScale= new Vector3(10,10,10);
		Car.transform.position = new Vector3 (Random.Range (-5, 5),0,  Random.Range (-5, 5));
		return Car;

	}
	// Hier wird ein neues Auto Erzeugt, aber erst wenn das Schreiben in die Datenbank erfolg hatte
	public static bool onstartpoint(){
		Database manageDatabase = new Database ();
		if(manageDatabase.getifactiveCarExists ()==false){
		string naming = "LP";
		naming = naming + System.Convert.ToChar(Random.Range (65, 90));
		naming = naming + System.Convert.ToChar(Random.Range (65, 90));
		naming = naming + Random.Range (25, 999);

		bool hatfunktioniert=manageDatabase.einchecken (naming);

		if (hatfunktioniert) {
			GameObject Car;
			Car = Instantiate (Resources.Load ("auto")) as GameObject;
			Car.name = naming;
			Car.transform.localScale = new Vector3 (10, 10, 10);
			Car.transform.position = new Vector3 (-7.74f, 2f, -11.53f);

			CreateCar.addrigidbody(Car);
			CreateCar.meshcollidersetconvextrue(Car);
			CreateCar.materialsColor(Car);
			Car.AddComponent<bewegeAuto>();
			
		}
			return hatfunktioniert;}
		else {
			return false;
		}

		
	}
	// Dem Jeweiligen Object wird eine RigidBody zugewiesen
	private static void addrigidbody(GameObject Car){
		Rigidbody newrig = Car.AddComponent<Rigidbody> ();
		newrig.mass = 1f;
		newrig.drag = 0;
		newrig.angularDrag = 0.5f;
		}
	// Diese Private funktion setzt bei der als Parameter vergebene GameObject alle Existierenden MeshCollider als Convex
	private static void meshcollidersetconvextrue(GameObject Car){
		MeshCollider[] meshcollider=Car.GetComponentsInChildren<MeshCollider>();
		Debug.Log(meshcollider.Length);
		for (int i=0;i<meshcollider.Length;i++){
			meshcollider[i].convex=true;
			meshcollider[1].smoothSphereCollisions=false;
		}
	}
	//Erzeugt zufällig eine Farbe für die AutoKarosserie
	private static void materialsColor(GameObject Car){

		 
		GameObject componente=null;
		Transform pTransform = Car.GetComponent<Transform>();
		foreach (Transform trs in pTransform) {
			if (trs.gameObject.name == "Cube_002"){
				componente =trs.gameObject;
			}
		}


		Material material = new Material (componente.renderer.material);

		material.color = new Color (Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));

			material.name = "NewLack";
		componente.renderer.material = material;


	}
	//Erzeugt Zufällig Autos und setzt sie auf Zufällige Parkplätze
	public static void randomfill(){

		Database manageDatabase = new Database ();
		int NumberoffreePArkplatz = manageDatabase.getanzahlfreeparkplaetze ();

		int anzahlrandomCars = Random.Range (5, NumberoffreePArkplatz / 2);
		for (int i=0; i<anzahlrandomCars; i++) {
			GameObject Car;
			Car = Instantiate(Resources.Load("auto")) as GameObject;
			string naming = "LP";
			naming = naming + System.Convert.ToChar(Random.Range (65, 90));
			naming = naming + System.Convert.ToChar(Random.Range (65, 90));
			naming = naming + Random.Range (25, 999);
			Car.name = naming;
			Parkplatz park= manageDatabase.getrandomfreeparkandfillwithcar(naming);
			Car.transform.localScale= new Vector3(10,10,10);
			Car.transform.position = new Vector3 (park.getX(),0.6f,park.getZ());
			CreateCar.addrigidbody(Car);
			CreateCar.meshcollidersetconvextrue(Car);
			CreateCar.materialsColor(Car);
			}
	
	}
	//Hier wird ein auto zum Kill freigegeben. Tatsächlicher kill wird aber erst in dem Script gemacht welche dem Auto Als Komponente beigefügt wird
	public static void KillCar(){
		Database manageDatabase = new Database ();
		Autos car =manageDatabase.getrandomparkingcar ();
		GameObject CarObject= GameObject.Find (car.getKennzeichen());
		CarObject.transform.position = new Vector3(-6.35434f,0.5f,-10.67066f);
		CarObject.transform.rotation = new Quaternion (0f, 180f, 0f, 1);
		manageDatabase.setcartoleave (car.getKennzeichen ());


	}
	
	
	}

