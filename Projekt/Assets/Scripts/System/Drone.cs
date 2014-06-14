//fertig Kommentiert
using UnityEngine;
using System.Collections;

// Author Burak Yarali
// Diese Klasse Gibt den Daten aus der Tabelle Drone eine Ansprechbare Umfällt.
// Diese Klasse Erleichtert das Umgeben mit den Daten
public class Drone  {
	string Name;
	int Aktuellerknoten;
	string LastUsed;
	int Homepunktid;
	int Status;

	public void setName(string Name){
		this.Name = Name;
		}

	public void setAktuellerknoten(string Nummer){
		this.Aktuellerknoten = System.Convert.ToInt32(Nummer);
	}


	public void setHomepunktid(string Nummer){
		this.Homepunktid = System.Convert.ToInt32(Nummer);
	}


	public void setStatus(string Nummer){
		this.Status = System.Convert.ToInt32(Nummer);
	}


	public void setLastused(string Nummer){
		this.LastUsed = Nummer;
	}

	public string getName(){
		return this.Name;
		}

	public int getAktuellerknoten(){
		return this.Aktuellerknoten;
	}

	public string getLastUsed(){
		return this.LastUsed;
	}

	public int getHomepunktID(){
		return this.Homepunktid;
	}

	public int getStatus(){
		return this.Status;
	}

}
