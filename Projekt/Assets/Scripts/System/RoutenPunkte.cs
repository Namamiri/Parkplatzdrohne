//fertig Kommentiert
using UnityEngine;
using System.Collections;

// Author Burak Yarali
// Diese Klasse Gibt den Daten aus der Tabelle RoutenPunkte eine Ansprechbare Umfällt.
// Diese Klasse Erleichtert das Umgeben mit den Daten
public class RoutenPunkte  {
	int ID;
	string Knotenname;
	float X;
	float Z;
	int TYPID;

	public void setID(string Nummer){
		this.ID = System.Convert.ToInt32(Nummer);
	}

	public void setX(string Nummer){

		this.X = System.Convert.ToSingle(Nummer);
	}

	public void setZ(string Nummer){
		this.Z = System.Convert.ToSingle(Nummer);
	}

	public void setTYPID(string Nummer){
		this.TYPID = System.Convert.ToInt32(Nummer);
	}

	public void setKNOTENNAME(string Nummer){
		this.Knotenname = Nummer;
	}

	public int getID(){
		return this.ID;
	}
	
	public float getX(){
		return this.X;
	}

	public float getZ(){
		return this.Z;
	}

	public int getTYPID(){
		return this.TYPID;
	}
	
	public string getKnotenname(){
		return this.Knotenname;
	}

}
