using UnityEngine;
using System.Collections;

public class Route {
	int RoutenID;
	int PositionID;
	int KnotenID;

	public void setRoutenID(string Nummer){
		this.RoutenID = System.Convert.ToInt32(Nummer);
	}
	
	public void setPositionID(string Nummer){
		this.PositionID = System.Convert.ToInt32(Nummer);
	}
	
	
	public void setKnotenID(string Nummer){
		this.KnotenID = System.Convert.ToInt32(Nummer);
	}

	public int getRoutenID(){
		return this.RoutenID;
	}
	
	public int getPositionID(){
		return this.PositionID;
	}
	
	public int getKnotenID(){
		return this.KnotenID;
	}

}
