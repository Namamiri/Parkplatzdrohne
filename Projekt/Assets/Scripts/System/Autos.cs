using UnityEngine;
using System.Collections;

public class Autos  {

	int ID;
	string Kennzeichen;
	int Status;

	public void setID(string ID){
		this.ID = System.Convert.ToInt32 (ID);
		}
	public void setKennzeichen(string Kennzeichen){
		this.Kennzeichen = Kennzeichen;
	}
	public void setStatus(string Status){
		this.Status = System.Convert.ToInt32 (Status);
	}

	public int getID(){
		return this.ID;
		}

	public int getStatus(){
		return this.Status;
		}

	public string getKennzeichen(){
		return this.Kennzeichen;
	}
}
