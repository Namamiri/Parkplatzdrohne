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
}
