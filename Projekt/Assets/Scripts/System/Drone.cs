using UnityEngine;
using System.Collections;

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
