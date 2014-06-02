using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RouteContainer  {

	List<Route> RoutenArray= new List<Route>();
	int aktuelPosition= 0;
	public void addRoute(Route ro){
		this.RoutenArray.Add (ro);
		}
	public Route getRoutespecPoint(int position){
		return this.RoutenArray [position];
	}

	public void clear(){
		this.RoutenArray.Clear();
	}

	public int getSize(){
		return this.RoutenArray.Count;
	}

	public Route getaktuelPosition(){
		return this.RoutenArray [this.aktuelPosition];
		}

	public bool gotonextPoint(){
		this.aktuelPosition=this.aktuelPosition+1;

		if (this.aktuelPosition == this.RoutenArray.Count || this.aktuelPosition > this.RoutenArray.Count) {
						return false;
			}
		else {
						return true;
		}

	}
}
