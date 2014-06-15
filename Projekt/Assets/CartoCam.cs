using UnityEngine;
using System.Collections;

public class CartoCam : MonoBehaviour {

	private Database manage = new Database ();




	void onGUI () {
		Transform GO1 = GameObject.Find("Main Camera").transform;
		Transform GO2 = GameObject.Find(manage.getActiveAuto().getKennzeichen()).transform;
		GO1.parent = GO2; //GO1 now child of GO2
	}
}
	/*public GameObject parent;
	//public GameObject cam;
	//public GameObject aktuellesAuto;

	public Transform cameraTransform = Camera.main.transform;
	public Transform parent = GameObject.Find (manage.getActiveAuto ().getKennzeichen ()).transform;

	void Example() {
		cameraTransform.parent = transform;
		cameraTransform.localPosition = -Vector3.forward * 5;
		cameraTransform.LookAt(transform);
	}
}*/


//public GameObject aktuellesAuto;
	//public GameObject cam;
	// Use this for initialization
	/*void Start () {
		GameObject.Find("Autokamera").transform.position = GameObject.Find (manage.getActiveAuto ().getKennzeichen ()).transform.position;
		print ("Position Kamera" + GameObject.Find("Autokamera").transform.position);
	}*/

	//void Update () {
		//parent=GameObject.Find(manage.getActiveAuto().getKennzeichen());
		//cam = GameObject.Find("Main Camera");
		//aktuellesAuto = GameObject.Find (manage.getActiveAuto ().getKennzeichen ());
		//		cam.transform.parent = parent.transform;

		//}
	
	/*// Update is called once per frame
	void Update ( ) {
		//aktuellesAuto = GameObject.Find (manage.getActiveAuto().getKennzeichen();
		//cam = GameObject.Find ("Main Camera");
	

	}

	public Transform cameraTransform = Camera.main.transform;
	void Example() {
		cameraTransform.parent = transform;
		cameraTransform.localPosition = -Vector3.forward * 5;
		cameraTransform.LookAt(transform);


	}

	obj = Instantiate(); obj.transform.parent = parentTransform
	transform.parent = otherGameObject.transform

	void Parent(GameObject aktuellesAuto, GameObject cam ){
		
		aktuellesAuto.transform.parent = cam.transform;
	}*/


