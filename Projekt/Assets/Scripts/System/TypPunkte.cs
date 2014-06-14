//fertig Kommentiert
using UnityEngine;
using System.Collections;

// Author Burak Yarali
// Diese Klasse Gibt den Daten aus der Tabelle TypPunkte eine Ansprechbare Umfällt.
// Diese Klasse Erleichtert das Umgeben mit den Daten
public class TypPunkte {
	int ID;
	string Typbezeichnung;

	public void setID(string Nummer){
		this.ID = System.Convert.ToInt32(Nummer);
	}
	
	
	public void setTypbezeichnung(string Nummer){
		this.Typbezeichnung = Nummer;
	}

	public int getID(){
		return this.ID;
	}
	
	public string getTypBezeichnung(){
		return this.Typbezeichnung;
	}
}
