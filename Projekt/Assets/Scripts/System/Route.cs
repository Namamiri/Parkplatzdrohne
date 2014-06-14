//fertig Kommentiert
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Author Burak Yarali
// Diese Klasse Gibt den Daten aus der Tabelle Route eine Ansprechbare Umfällt.
// Diese Klasse Erleichtert das Umgeben mit den Daten
public class Route {
	int RoutenID;
	int PositionID;
	int KnotenID;

	public void setRoutenID(string Nummer){
		this.RoutenID = System.Convert.ToInt32(Nummer);
	}
	
	public void setPositionID(string Nummer){
		this.PositionID = System.Convert.ToInt32(Nummer);
	}
	
	
	public void setKnotenID(string Nummer){
		this.KnotenID = System.Convert.ToInt32(Nummer);
	}

	public int getRoutenID(){
		return this.RoutenID;
	}
	
	public int getPositionID(){
		return this.PositionID;
	}
	
	public int getKnotenID(){
		return this.KnotenID;
	}

}
