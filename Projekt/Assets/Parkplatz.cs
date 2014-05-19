using UnityEngine;
using System.Collections;

public class Parkplatz  {

	int PARKPLATZNUMMER;
	int ROUTENID;
	int FREI;
	string KENNZEICHENFAHRZEUG;

	public void setPARKPLATZNUMMER(string Nummer){
		this.PARKPLATZNUMMER = System.Convert.ToInt32(Nummer);
	}

	public void setROUTENID(string Nummer){
		this.ROUTENID = System.Convert.ToInt32(Nummer);
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
	
	public int setROUTENID(){
		return this.ROUTENID;
	}
	
	public int setFREI(){
		return this.FREI;
	}
	
	public string setKENNZEICHEN(){
		return this.KENNZEICHENFAHRZEUG;
	}


}
