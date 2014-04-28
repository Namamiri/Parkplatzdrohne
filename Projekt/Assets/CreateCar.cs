using UnityEngine;
using System.Collections;

public class CreateCar : MonoBehaviour {

	public static GameObject fromPrefab(){
		GameObject Car;
		Debug.Log("Car");
		Car = Instantiate(Resources.Load ("Sphere")) as GameObject;
		Car.transform.Translate (new Vector3 (3, 3, 3));
		return Car;
	}
}
