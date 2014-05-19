using UnityEngine;
using System.Collections;

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
