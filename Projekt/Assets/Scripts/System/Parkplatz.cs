//fertig Kommentiert
using UnityEngine;
using System.Collections;

// Author Burak Yarali
// Diese Klasse Gibt den Daten aus der Tabelle Parkplatz eine Ansprechbare Umfeld.
// Diese Klasse Erleichtert das Umgeben mit den Daten
public class Parkplatz  {

	int PARKPLATZNUMMER;
	int ROUTENID;
	int FREI;
	string KENNZEICHENFAHRZEUG;
	float XKOORD;
	float ZKOORD;

	public void setPARKPLATZNUMMER(string Nummer){
		this.PARKPLATZNUMMER = System.Convert.ToInt32(Nummer);
	}

	public void setROUTENID(string Nummer){
		this.ROUTENID = System.Convert.ToInt32(Nummer);
	}

	public void setXKOORD(string Nummer){
		this.XKOORD = System.Convert.ToSingle(Nummer);
	}

	public void setZKOORD(string Nummer){
		this.ZKOORD = System.Convert.ToSingle(Nummer);
	}

	public void setFREI(string Nummer){
		this.FREI = System.Convert.ToInt32(Nummer);
	}

	public void setKENNZEICHEN(string Nummer){
		this.KENNZEICHENFAHRZEUG = Nummer;
	}



	public int getPARKPLATZNUMMER(){
		return this.PARKPLATZNUMMER;
	}
	
	public int getROUTENID(){
		return this.ROUTENID;
	}
	
	public int getFREI(){
		return this.FREI;
	}

	public float getX(){
		return this.XKOORD;
	}

	public float getZ(){
		return this.ZKOORD;
	}
	
	public string getKENNZEICHEN(){
		return this.KENNZEICHENFAHRZEUG;
	}


}
