using UnityEngine;
using System.Collections;

public class WayPointControl  {

	static Database ManageDatabase = new Database ();
	static GameObject WayPointPack11 = GameObject.Find ("Routenpunkt1");
	static GameObject WayPointPack12 = GameObject.Find ("Routenpunkt2");
	static GameObject WayPointPack13 = GameObject.Find ("Routenpunkt3");
	static GameObject WayPointPack14 = GameObject.Find ("Routenpunkt4");
	static GameObject WayPointPack31 = GameObject.Find ("RPR1");
	static GameObject WayPointPack32 = GameObject.Find ("RPR2");
	static Autos auto;
	static Parkplatz parki;
	static RouteContainer routepoints;
	static RoutenPunkte punkt;
	public static void UmstellenderWayPoints(){


		auto = ManageDatabase.getActiveAuto ();
		Debug.Log (" WaypointControl Kennzeichen " + auto.getKennzeichen ());
		int i = 0;
		ManageDatabase.getParkplatzViaKennzeichencount (auto.getKennzeichen());
		parki = ManageDatabase.getParkplatzViaKennzeichen (auto.getKennzeichen ());
		routepoints = ManageDatabase.getRouteViaROUTEID (System.Convert.ToString(parki.getROUTENID ()));
		Debug.Log (routepoints.getSize ());
		if (routepoints.getSize() == 3) {
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(0).getKnotenID()));
			WayPointPack11.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(1).getKnotenID()));
			WayPointPack12.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(2).getKnotenID()));
			WayPointPack13.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			WayPointPack14.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			WayPointPack31.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			WayPointPack32.transform.position=new Vector3(punkt.getX(),3.339992f,punkt.getZ());

				}
		else if(routepoints.getSize()==4){
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(0).getKnotenID()));
			WayPointPack11.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(1).getKnotenID()));
			WayPointPack12.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(2).getKnotenID()));
			WayPointPack13.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(3).getKnotenID()));
			WayPointPack14.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			WayPointPack31.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			WayPointPack32.transform.position=new Vector3(punkt.getX(),3.339992f,punkt.getZ());
		}
		}
}
