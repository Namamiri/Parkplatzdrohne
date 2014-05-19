using UnityEngine;
using System.Collections;

public class RoutenPunkte  {
	int ID;
	string Knotenname;
	int X;
	int Y;
	int TYPID;

	public void setID(string Nummer){
		this.ID = System.Convert.ToInt32(Nummer);
	}

	public void setX(string Nummer){
		this.X = System.Convert.ToInt32(Nummer);
	}

	public void setY(string Nummer){
		this.Y = System.Convert.ToInt32(Nummer);
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
	
	public int getX(){
		return this.X;
	}

	public int getY(){
		return this.Y;
	}

	public int getTYPID(){
		return this.TYPID;
	}
	
	public string geKnotenname(){
		return this.Knotenname;
	}

}
