using UnityEngine;
using System.Collections;

public class Autos  {

	int ID;
	string Kennzeichen;
	int Status;

	void setID(string ID){
		this.ID = System.Convert.ToInt32 (ID);
		}
	void setKennzeichen(string Kennzeichen){
		this.Kennzeichen = Kennzeichen;
	}
	void setStatus(string Status){
		this.Status = System.Convert.ToInt32 (Status);
	}

	int getID(){
		return this.ID;
		}
	string getKennzeichen(){
		return this.Kennzeichen;
		}
	int getStatus(){
		return this.Status;
		}
}
