using UnityEngine;
using System.Collections;

public class CreateCar : MonoBehaviour {

	public static GameObject fromPrefab(){
		GameObject Car;
		Debug.Log("Car");
		Car = Instantiate(Resources.Load ("Capsule")) as GameObject;
		Car.transform.Translate (new Vector3 (3, 3, 3));
		return Car;

	}

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

	public static bool onstartpoint(){
		Database manageDatabase = new Database ();

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
			Rigidbody newrig = Car.AddComponent<Rigidbody> ();
			newrig.mass = 1f;
			newrig.drag = 0;
			newrig.angularDrag = 0.5f;
			CreateCar.meshcollidersetconvextrue(Car);
		}
		return hatfunktioniert;
		
	}

	private static void meshcollidersetconvextrue(GameObject Car){
		MeshCollider[] meshcollider=Car.GetComponentsInChildren<MeshCollider>();
		Debug.Log(meshcollider.Length);
		for (int i=0;i<meshcollider.Length;i++){
			meshcollider[i].convex=true;
			meshcollider[1].smoothSphereCollisions=false;
		}
	}

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
			Car.transform.position = new Vector3 (park.getX(),2f,park.getZ());
			Rigidbody newrig = Car.AddComponent<Rigidbody>();
			newrig.mass = 1f;
			newrig.drag = 0;
			newrig.angularDrag = 0.5f;
			CreateCar.meshcollidersetconvextrue(Car);

			}
	
	}
	
	
	}

