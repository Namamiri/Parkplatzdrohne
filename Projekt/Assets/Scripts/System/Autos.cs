// fertig Kommentiert
using UnityEngine;
using System.Collections;

// Author Burak Yarali
// Diese Klasse Gibt den Daten aus der Tabelle Autos eine ansprechbare Umfeld.
// Diese Klasse Erleichtert das Umgeben mit den Daten
public class Autos  {


	string Kennzeichen;
	int Status;


	public void setKennzeichen(string Kennzeichen){
		this.Kennzeichen = Kennzeichen;
	}
	public void setStatus(string Status){
		this.Status = System.Convert.ToInt32 (Status);
	}


	public int getStatus(){
		return this.Status;
		}

	public string getKennzeichen(){
		return this.Kennzeichen;
	}
}
