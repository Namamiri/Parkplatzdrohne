using UnityEngine;
using System.Collections;

public class WayPointControl  {



	public static void UmstellenderWayPoints(){
		Database ManageDatabase = new Database ();
		GameObject WayPointPack11 = GameObject.Find ("Routenpunkt1");
		GameObject WayPointPack12 = GameObject.Find ("Routenpunkt2");
		GameObject WayPointPack13 = GameObject.Find ("Routenpunkt3");
		GameObject WayPointPack14 = GameObject.Find ("Routenpunkt4");
		GameObject WayPointPack31 = GameObject.Find ("RoutenpunktR1");
		Autos auto = ManageDatabase.getActiveAuto ();
		Debug.Log (" WaypointControl Kennzeichen " + auto.getKennzeichen ());
		int i = 0;
		ManageDatabase.getParkplatzViaKennzeichencount (auto.getKennzeichen());
		Parkplatz parki = ManageDatabase.getParkplatzViaKennzeichen (auto.getKennzeichen ());
		RouteContainer routepoints = ManageDatabase.getRouteViaROUTEID (System.Convert.ToString(parki.getROUTENID ()));
		Debug.Log (routepoints.getSize ());
		if (routepoints.getSize() == 3) {
			RoutenPunkte punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(0).getKnotenID()));
			WayPointPack11.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(1).getKnotenID()));
			WayPointPack12.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(2).getKnotenID()));
			WayPointPack13.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			WayPointPack14.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			WayPointPack31.transform.position=new Vector3(punkt.getX(),3.339992f,punkt.getZ());
				}
		else if(routepoints.getSize()==4){
			RoutenPunkte punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(0).getKnotenID()));
			WayPointPack11.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(1).getKnotenID()));
			WayPointPack12.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(2).getKnotenID()));
			WayPointPack13.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			punkt=ManageDatabase.getRoutePointViaID(System.Convert.ToString(routepoints.getRoutespecPoint(3).getKnotenID()));
			WayPointPack14.transform.position=new Vector3(punkt.getX(),0.8211908f,punkt.getZ());
			WayPointPack31.transform.position=new Vector3(punkt.getX(),3.339992f,punkt.getZ());
		}
		}
}
