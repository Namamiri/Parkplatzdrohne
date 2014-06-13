using UnityEngine;
using System.Collections;

public class WayPointControl  {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UmstellenderWayPoints(){
		Database ManageDatabase = new Database ();
		GameObject WayPointPack11 = GameObject.Find ("Routenpunkt1");
		GameObject WayPointPack12 = GameObject.Find ("Routenpunkt2");
		GameObject WayPointPack13 = GameObject.Find ("Routenpunkt3");
		GameObject WayPointPack14 = GameObject.Find ("Routenpunkt4");
		Autos auto = ManageDatabase.getActiveAuto ();
		Parkplatz parki = ManageDatabase.getParkplatzViaKennzeichen (auto.getKennzeichen ());
		RouteContainer routepoints = ManageDatabase.getRouteViaROUTEID (parki.getROUTENID ());
		if (routepoints.getSize == 3) {
			RoutenPunkte punkt=ManageDatabase.getRoutePointViaID(routepoints.getRoutespecPoint(0).getKnotenID());
			WayPointPack11.transform.position()=new Vector3(punkt.getX(),0,punkt.getZ());
				}
		}
}
