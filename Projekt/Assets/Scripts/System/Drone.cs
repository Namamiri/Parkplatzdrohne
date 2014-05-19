using UnityEngine;
using System.Collections;

public class Drone  {
	int ID;
	int Aktuellerknoten;
	string LastUsed;
	int Homepunktid;
	int Usingtruefalse;

	public void setID(string Nummer){
		this.ID = System.Convert.ToInt32(Nummer);
	}

	public void setAktuellerknoten(string Nummer){
		this.Aktuellerknoten = System.Convert.ToInt32(Nummer);
	}


	public void setHomepunktid(string Nummer){
		this.Homepunktid = System.Convert.ToInt32(Nummer);
	}


	public void setUsingtruefalse(string Nummer){
		this.Usingtruefalse = System.Convert.ToInt32(Nummer);
	}


	public void setLastused(string Nummer){
		this.LastUsed = Nummer;
	}

	
	public int getID(){
		return this.ID;
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

	public int getUsingtruefalse(){
		return this.Usingtruefalse;
	}

}
