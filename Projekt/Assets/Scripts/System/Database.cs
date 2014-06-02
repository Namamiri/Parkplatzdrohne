using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;
using System;
using System.Collections.Generic;

[ExecuteInEditMode()]  
public class Database {
	string _strDBName = "URI=file:MasterSQLite.db";

	public void Start () {
		Debug.Log("Datenbankklasse startet");

		//_connection .Open();

		//sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";
		//_command.CommandText = sql;
		//_command.ExecuteNonQuery();

		//sql = "INSERT INTO highscores (name, score) VALUES ('Me', 3000)";
		//_command.CommandText = sql;
		//_command.ExecuteNonQuery();

		//sql = "insert into highscores (name, score) values ('Myself', 6000)";
		//_command.CommandText = sql;
		//_command.ExecuteNonQuery();

		//sql = "insert into highscores (name, score) values ('And I', 9001)";
		//_command.CommandText = sql;
		//_command.ExecuteNonQuery();

		//sql = "select * from highscores order by score desc";
		//_command.CommandText = sql;
		
		//IDataReader _reader = _command.ExecuteReader();

		//while (_reader.Read())
		//	Debug.Log("****** Name: " + _reader["name"] + "\tScore: " + _reader["score"]);
			
		//_reader.Close();
		//_reader = null;
		//_command.Dispose();
		//_command = null;
		//_connection .Close();
		//_connection = null;
		this.createDatabase ();



	}
	
	// Update is called once per frame
	void Update () {
	}
	public int abfrageexisttabelle(string Tabellenname){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT count(name) as Count FROM sqlite_master WHERE type='table' AND name='"+Tabellenname+"'";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		_reader.Read ();
		_connection .Close();
		_connection = null;
		_reader.Close();
		Debug.Log (_reader ["Count"]);
		return System.Convert.ToInt32(_reader["Count"]);


	}

	public void filltableParkplatz(){
		Debug.Log ("fillPArk");
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From PARKPLATZ";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();

		_connection.Close ();

			Parkplatz park = new Parkplatz ();
		park.setROUTENID ("1"); park.setPARKPLATZNUMMER("1");park.setXKOORD ("-6.37327");park.setZKOORD ("-19.48297");this.addParkPlatz (park);
		park.setROUTENID ("2"); park.setPARKPLATZNUMMER("2");park.setXKOORD ("-6.37327");park.setZKOORD ("-18.87943");this.addParkPlatz (park);


	}

	void addParkPlatz(Parkplatz park){

		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection .Open();
		sql = "INSERT INTO PARKPLATZ (PARKPLATZNUMMER, ROUTENID, FREI, KENNZEICHENFAHRZEUG, XKOORD, ZKOORD) Values ("+park.getPARKPLATZNUMMER()+","+park.getROUTENID()+", 1,0,"+park.getX()+","+park.getY()+")";
		_command.CommandText = sql;
		_command.ExecuteReader();

		_command.Dispose ();
		_connection.Close ();
		Debug.Log ("Parkplatz NR. " + park.getPARKPLATZNUMMER () + " ; RoutenID " + park.getROUTENID());
	}

	void addTypforPunkt(TypPunkte typen){
		
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection .Open();
		sql = "INSERT INTO TYPPUNKTE (ID, TYPBEZEICHNUNG) Values ("+typen.getID()+",'"+typen.getTypBezeichnung()+"')";
		_command.CommandText = sql;
		_command.ExecuteReader();
		
		_command.Dispose ();
		_connection.Close ();
		Debug.Log ("TypID " + typen.getID()+ " ; TypBezeichnung " + typen.getTypBezeichnung());
	}

	public void fillTypPunkt(){
		Debug.Log ("fillTypPunkte");
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From Routenpunkte";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		
		_connection.Close ();

		TypPunkte typen = new TypPunkte ();
		typen.setID ("1"); typen.setTypbezeichnung ("Abzweigung"); this.addTypforPunkt (typen);
		typen.setID ("2"); typen.setTypbezeichnung ("ParkPlatzFront"); this.addTypforPunkt (typen);
		typen.setID ("3"); typen.setTypbezeichnung ("Parkplatz"); this.addTypforPunkt (typen);
		typen.setID ("4"); typen.setTypbezeichnung ("Start"); this.addTypforPunkt (typen);
	}

	void addRoutenPunkte(RoutenPunkte punkte){
		
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection .Open();
		sql = "INSERT INTO Routenpunkte (ID, Knotenname, XKOORD, ZKOORD, TYPID) Values ("+punkte.getID()+",'"+punkte.getKnotenname()+"',"+punkte.getX()+","+punkte.getZ()+","+punkte.getTYPID()+")";
		_command.CommandText = sql;
		_command.ExecuteReader();
		
		_command.Dispose ();
		_connection.Close ();
		Debug.Log ("KnotenID " + punkte.getID() + " ; KnotenName " + punkte.getKnotenname()+" ; XKOORD: "+punkte.getX()+" ; ZKOORD: "+punkte.getZ());
	}

	void addRoute(Route punkte){
		
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection .Open();
		sql = "INSERT INTO ROUTE (ROUTENID, POSITION, PUNKTID) Values ("+punkte.getRoutenID+",'"+punkte.getPositionID+"',"+punkte.getKnotenID+")";
		_command.CommandText = sql;
		_command.ExecuteReader();
		
		_command.Dispose ();
		_connection.Close ();
		Debug.Log ("KnotenID " + punkte.getKnotenID + " ; Position " + punkte.getPositionID+" ; RoutenID: "+punkte.getRoutenID());
	}

	public void filltableRoute(){
		Debug.Log ("RoutePoints");
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From Routenpunkte";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		
		_connection.Close ();

		Route PointstoRoute = new Route ();
		//First Route
		PointstoRoute.setRoutenID ("1");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("1");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("2");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("1");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("3");this.addRoute (PointstoRoute);
		//Second Route
		PointstoRoute.setRoutenID ("2");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("2");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("4");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("2");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("5");this.addRoute (PointstoRoute);
		//Third Route
		PointstoRoute.setRoutenID ("3");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("3");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("6");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("3");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("7");this.addRoute (PointstoRoute);
		//Fourth Route
		PointstoRoute.setRoutenID ("4");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("4");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("8");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("4");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("9");this.addRoute (PointstoRoute);
		//Fifth Route
		PointstoRoute.setRoutenID ("5");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("5");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("8");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("5");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("10");this.addRoute (PointstoRoute);
		//Six Route
		PointstoRoute.setRoutenID ("6");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("6");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("11");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("6");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("12");this.addRoute (PointstoRoute);
		//Seven Route
		PointstoRoute.setRoutenID ("7");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("7");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("11");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("7");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("13");this.addRoute (PointstoRoute);
		//eight Route
		PointstoRoute.setRoutenID ("8");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("8");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("14");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("8");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("15");this.addRoute (PointstoRoute);
		//nine Route
		PointstoRoute.setRoutenID ("9");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("9");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("14");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("9");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("16");this.addRoute (PointstoRoute);
		//ten Route
		PointstoRoute.setRoutenID ("10");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("10");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("17");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("10");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("18");this.addRoute (PointstoRoute);
		//eleven Route
		PointstoRoute.setRoutenID ("11");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("11");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("17");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("11");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("19");this.addRoute (PointstoRoute);
		//12 Route
		PointstoRoute.setRoutenID ("12");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("12");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("20");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("12");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("21");this.addRoute (PointstoRoute);
		//13 Route
		PointstoRoute.setRoutenID ("13");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("13");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("20");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("13");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("22");this.addRoute (PointstoRoute);
		//14 Route
		PointstoRoute.setRoutenID ("14");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("14");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("23");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("14");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("24");this.addRoute (PointstoRoute);
		//15 Route
		PointstoRoute.setRoutenID ("15");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("15");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("23");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("15");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("25");this.addRoute (PointstoRoute);
		//16 Route
		PointstoRoute.setRoutenID ("16");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("16");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("26");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("16");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("27");this.addRoute (PointstoRoute);
		//17 Route
		PointstoRoute.setRoutenID ("17");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("17");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("26");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("17");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("28");this.addRoute (PointstoRoute);
		//18 Route
		PointstoRoute.setRoutenID ("18");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("18");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("29");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("18");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("30");this.addRoute (PointstoRoute);
		//19 Route
		PointstoRoute.setRoutenID ("19");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("1");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("19");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("29");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("19");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("31");this.addRoute (PointstoRoute);


	}
	public void filltableRoutenPunkte(){
		Debug.Log ("RoutePoints");
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From Routenpunkte";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		
		_connection.Close ();

		RoutenPunkte Punkt = new RoutenPunkte ();

		Punkt.setID ("1");Punkt.setKNOTENNAME ("FirstKnotR");Punkt.setX ("-5.31386"); Punkt.setZ ("-11.65559");Punkt.setTYPID("1");this.addRoutenPunkte (Punkt);

		Punkt.setID ("2");Punkt.setKNOTENNAME ("FrontPK1");Punkt.setX ("-5.31386"); Punkt.setZ ("-19.48297");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("3");Punkt.setKNOTENNAME ("PK1");Punkt.setX ("-6.37327"); Punkt.setZ ("-19.48297");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("4");Punkt.setKNOTENNAME ("FrontPK2");Punkt.setX ("-5.31386"); Punkt.setZ ("-18.87943");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("5");Punkt.setKNOTENNAME ("PK2");Punkt.setX ("-6.37327"); Punkt.setZ ("-18.87943");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("6");Punkt.setKNOTENNAME ("FrontPK3");Punkt.setX ("-5.31386"); Punkt.setZ ("-18.20297");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("7");Punkt.setKNOTENNAME ("PK3");Punkt.setX ("-6.37327"); Punkt.setZ ("-18.20297");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("8");Punkt.setKNOTENNAME ("FrontPK4-PK5");Punkt.setX ("-5.31386"); Punkt.setZ ("-17.58915");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("9");Punkt.setKNOTENNAME ("PK4");Punkt.setX ("-6.37327"); Punkt.setZ ("-17.58915");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("10");Punkt.setKNOTENNAME ("PK5");Punkt.setX ("-3.698879"); Punkt.setZ ("-17.58915");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("11");Punkt.setKNOTENNAME ("FrontPK6-PK7");Punkt.setX ("-5.31386"); Punkt.setZ ("-16.93814");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("12");Punkt.setKNOTENNAME ("PK6");Punkt.setX ("-6.37327"); Punkt.setZ ("-16.93814");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("13");Punkt.setKNOTENNAME ("PK7");Punkt.setX ("-3.698879"); Punkt.setZ ("-16.93814");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("14");Punkt.setKNOTENNAME ("FrontPK8-PK9");Punkt.setX ("-5.31386"); Punkt.setZ ("-16.28712");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("15");Punkt.setKNOTENNAME ("PK8");Punkt.setX ("-6.37327"); Punkt.setZ ("-16.28712");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("16");Punkt.setKNOTENNAME ("PK9");Punkt.setX ("-3.698879"); Punkt.setZ ("-16.28712");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("17");Punkt.setKNOTENNAME ("FrontPK10-PK11");Punkt.setX ("-5.31386"); Punkt.setZ ("-15.6175");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("18");Punkt.setKNOTENNAME ("PK10");Punkt.setX ("-6.37327"); Punkt.setZ ("-15.6175");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("19");Punkt.setKNOTENNAME ("PK11");Punkt.setX ("-3.698879"); Punkt.setZ ("-15.6175");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("20");Punkt.setKNOTENNAME ("FrontPK12-PK13");Punkt.setX ("-5.31386"); Punkt.setZ ("-14.98962");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("21");Punkt.setKNOTENNAME ("PK12");Punkt.setX ("-6.37327"); Punkt.setZ ("-14.98962");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("22");Punkt.setKNOTENNAME ("PK13");Punkt.setX ("-3.698879"); Punkt.setZ ("-14.98962");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("23");Punkt.setKNOTENNAME ("FrontPK14-PK15");Punkt.setX ("-5.31386"); Punkt.setZ ("-14.35225");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("24");Punkt.setKNOTENNAME ("PK14");Punkt.setX ("-6.37327"); Punkt.setZ ("-14.35225");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("25");Punkt.setKNOTENNAME ("PK15");Punkt.setX ("-3.698879"); Punkt.setZ ("-14.35225");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("26");Punkt.setKNOTENNAME ("FrontPK16-PK17");Punkt.setX ("-5.31386"); Punkt.setZ ("-13.71087");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("27");Punkt.setKNOTENNAME ("PK16");Punkt.setX ("-6.37327"); Punkt.setZ ("-13.71087");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("28");Punkt.setKNOTENNAME ("PK17");Punkt.setX ("-3.698879"); Punkt.setZ ("-13.71087");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("29");Punkt.setKNOTENNAME ("FrontPK18-PK19");Punkt.setX ("-5.31386"); Punkt.setZ ("-13.06949");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("30");Punkt.setKNOTENNAME ("PK18");Punkt.setX ("-6.37327"); Punkt.setZ ("-13.06949");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("31");Punkt.setKNOTENNAME ("PK19");Punkt.setX ("-3.698879"); Punkt.setZ ("-13.06949");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);

		Punkt.setID ("57");Punkt.setKNOTENNAME ("FirstKnotL");Punkt.setX ("-4.642091"); Punkt.setZ ("-10.48455");Punkt.setTYPID("1");this.addRoutenPunkte (Punkt);

		Punkt.setID ("58");Punkt.setKNOTENNAME ("FrontPK35-PK36");Punkt.setX ("-4.642091"); Punkt.setZ ("-9.18896");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("59");Punkt.setKNOTENNAME ("PK35");Punkt.setX ("-3.707438"); Punkt.setZ ("-9.18896");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("60");Punkt.setKNOTENNAME ("PK36");Punkt.setX ("-6.395954"); Punkt.setZ ("-9.18896");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("61");Punkt.setKNOTENNAME ("FrontPK37-PK38");Punkt.setX ("-4.642091"); Punkt.setZ ("-8.533358");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("62");Punkt.setKNOTENNAME ("PK37");Punkt.setX ("-3.707438"); Punkt.setZ ("-8.533358");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("63");Punkt.setKNOTENNAME ("PK38");Punkt.setX ("-6.395954"); Punkt.setZ ("-8.533358");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("64");Punkt.setKNOTENNAME ("FrontPK39-PK40");Punkt.setX ("-4.642091"); Punkt.setZ ("-7.890867");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("65");Punkt.setKNOTENNAME ("PK39");Punkt.setX ("-3.707438"); Punkt.setZ ("-7.890867");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("66");Punkt.setKNOTENNAME ("PK40");Punkt.setX ("-6.395954"); Punkt.setZ ("-7.890867");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("67");Punkt.setKNOTENNAME ("FrontPK41-PK42");Punkt.setX ("-4.642091"); Punkt.setZ ("-7.261488");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("68");Punkt.setKNOTENNAME ("PK41");Punkt.setX ("-3.707438"); Punkt.setZ ("-7.261488");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("69");Punkt.setKNOTENNAME ("PK42");Punkt.setX ("-6.395954"); Punkt.setZ ("-7.261488");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("70");Punkt.setKNOTENNAME ("FrontPK43-PK44");Punkt.setX ("-4.642091"); Punkt.setZ ("-6.632109");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("71");Punkt.setKNOTENNAME ("PK43");Punkt.setX ("-3.707438"); Punkt.setZ ("-6.632109");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("72");Punkt.setKNOTENNAME ("PK44");Punkt.setX ("-6.395954"); Punkt.setZ ("-6.632109");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("73");Punkt.setKNOTENNAME ("FrontPK45-PK46");Punkt.setX ("-4.642091"); Punkt.setZ ("-5.989618");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("74");Punkt.setKNOTENNAME ("PK45");Punkt.setX ("-3.707438"); Punkt.setZ ("-5.989618");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("75");Punkt.setKNOTENNAME ("PK46");Punkt.setX ("-6.395954"); Punkt.setZ ("-5.989618");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);

		Punkt.setID ("32");Punkt.setKNOTENNAME ("SecondKnot");Punkt.setX ("-0.8945427"); Punkt.setZ ("-11.58572");Punkt.setTYPID("1");this.addRoutenPunkte (Punkt);

		Punkt.setID ("33");Punkt.setKNOTENNAME ("FrontPK20");Punkt.setX ("-0.8945427"); Punkt.setZ ("-17.57712");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("34");Punkt.setKNOTENNAME ("PK20");Punkt.setX ("-1.8369"); Punkt.setZ ("-17.57712");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("35");Punkt.setKNOTENNAME ("FrontPK21-PK22");Punkt.setX ("-0.8945427"); Punkt.setZ ("-16.93082");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("36");Punkt.setKNOTENNAME ("PK21");Punkt.setX ("-1.8369"); Punkt.setZ ("-16.93082");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("37");Punkt.setKNOTENNAME ("PK22");Punkt.setX ("0.8356519"); Punkt.setZ ("-16.93082");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("38");Punkt.setKNOTENNAME ("FrontPK23-PK24");Punkt.setX ("-0.8945427"); Punkt.setZ ("-16.30198");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("39");Punkt.setKNOTENNAME ("PK23");Punkt.setX ("-1.8369"); Punkt.setZ ("-16.30198");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("40");Punkt.setKNOTENNAME ("PK24");Punkt.setX ("0.8356519"); Punkt.setZ ("-16.30198");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("41");Punkt.setKNOTENNAME ("FrontPK25-PK26");Punkt.setX ("-0.8945427"); Punkt.setZ ("-15.63583");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("42");Punkt.setKNOTENNAME ("PK25");Punkt.setX ("-1.8369"); Punkt.setZ ("-15.63583");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("43");Punkt.setKNOTENNAME ("PK26");Punkt.setX ("0.8356519"); Punkt.setZ ("-15.63583");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("44");Punkt.setKNOTENNAME ("FrontPK27-PK28");Punkt.setX ("-0.8945427"); Punkt.setZ ("-14.97135");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("45");Punkt.setKNOTENNAME ("PK27");Punkt.setX ("-1.8369"); Punkt.setZ ("-14.97135");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("46");Punkt.setKNOTENNAME ("PK28");Punkt.setX ("0.8356519"); Punkt.setZ ("-14.97135");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("47");Punkt.setKNOTENNAME ("FrontPK29-PK30");Punkt.setX ("-0.8945427"); Punkt.setZ ("-14.36225");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("48");Punkt.setKNOTENNAME ("PK29");Punkt.setX ("-1.8369"); Punkt.setZ ("-14.36225");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("49");Punkt.setKNOTENNAME ("PK30");Punkt.setX ("0.8356519"); Punkt.setZ ("-14.36225");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("50");Punkt.setKNOTENNAME ("FrontPK31-PK32");Punkt.setX ("-0.8945427"); Punkt.setZ ("-13.71623");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("51");Punkt.setKNOTENNAME ("PK31");Punkt.setX ("-1.8369"); Punkt.setZ ("-13.71623");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("52");Punkt.setKNOTENNAME ("PK32");Punkt.setX ("0.8356519"); Punkt.setZ ("-13.71623");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("53");Punkt.setKNOTENNAME ("FrontPK33-PK34");Punkt.setX ("-0.8945427"); Punkt.setZ ("-13.08867");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("54");Punkt.setKNOTENNAME ("PK33");Punkt.setX ("-1.8369"); Punkt.setZ ("-13.08867");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("55");Punkt.setKNOTENNAME ("PK34");Punkt.setX ("0.8356519"); Punkt.setZ ("-13.08867");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
	
		Punkt.setID ("56");Punkt.setKNOTENNAME ("ThirdKnot");Punkt.setX ("3.582275"); Punkt.setZ ("-11.58572");Punkt.setTYPID("1");this.addRoutenPunkte (Punkt);


	}

	public void createDatabase(){

		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;

		_connection .Open();

		//deleteTabelle ("Routenpunkte");

		if (abfrageexisttabelle ("Routenpunkte") == 0) {
			sql = "CREATE TABLE Routenpunkte (ID INT , Knotenname VARCHAR(55), XKOORD FLOAT, ZKOORD FLOAT, TYPID INT, PRIMARY KEY(ID))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery ();
				} else {
			Debug.Log("Routenpunkte Exists");
				}

		//deleteTabelle ("TYPPUNKTE");

		if (abfrageexisttabelle ("TYPPUNKTE") == 0) {
			sql = "CREATE TABLE TYPPUNKTE (ID INT, TYPBEZEICHNUNG VARCHAR(55), PRIMARY KEY(ID))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("TYPPUNKTE Exists");
		}

		//deleteTabelle ("ROUTE");

		if (abfrageexisttabelle ("ROUTE") == 0) {
						sql = "CREATE TABLE ROUTE (ROUTENID INT, POSITION INT, PUNKTID INT, PRIMARY KEY(ROUTENID, POSITION))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("ROUTE Exists");
		}

		deleteTabelle ("PARKPLATZ");

		if (abfrageexisttabelle ("PARKPLATZ") == 0) {
			sql = "CREATE TABLE PARKPLATZ (PARKPLATZNUMMER INT, ROUTENID INT, FREI INT, KENNZEICHENFAHRZEUG VARCHAR(12), XKOORD FLOAT, ZKOORD FLOAT, PRIMARY KEY(PARKPLATZNUMMER))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("PARKPLATZ Exists");
		}

		//deleteTabelle ("DRONEN");

		if (abfrageexisttabelle ("DRONEN") == 0) {
			sql = "CREATE TABLE DRONEN (ID INT, AKTUELLERKNOTEN INT, LASTUSED DATE, HOMEPUNKTID INT, USINGTRUEFALSE INT,  PRIMARY KEY(ID))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("DRONEN Exists");
		}

		//deleteTabelle ("AUTOS");

		if (abfrageexisttabelle ("AUTOS") == 0) {
			sql = "CREATE TABLE AUTOS (ID INT, KENNZEICHEN VARCHAR(15), STATUS INT,  PRIMARY KEY(ID))";
			_command.CommandText = sql;
			_command.ExecuteNonQuery();
		} else {
			Debug.Log("AUTOS Exists");
		}

		_command.Dispose();
		//_command = null;
		_connection .Close();
		//_connection = null;
	}
	public void deleteTabelle(string Tabelle){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection .Open();
		sql = "DROP TABLE IF EXISTS "+Tabelle+" ";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();


		_command.Dispose();
		_connection .Close();
		}

	public List<Parkplatz> getfreeParkplatz(){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT * FROM PARKPLATZ WHERE FREI=1 ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		List<Parkplatz> Liste= new List<Parkplatz> ();
		while (_reader.Read ()) {
			Parkplatz platz=new Parkplatz();
			platz.setPARKPLATZNUMMER(_reader["PARKPLATZNUMMER"] as String);
			platz.setFREI(_reader["FREI"] as String);
			platz.setKENNZEICHEN(_reader["KENNZEICHENFAHRZEUG"] as String);
			platz.setROUTENID(_reader["ROUTENID"] as String);

			Liste.Add(platz);

				};

		
		_command.Dispose();
		_connection .Close();
		_connection = null;
		_reader.Close();
		return Liste;
	}

	public void addauto(Autos autodaten){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		
		_connection .Open();

		sql = "INSERT INTO AUTOS (KENNZEICHEN, STATUS) Values ('"+ autodaten.getKennzeichen ()+"','"+autodaten.getStatus ()+"')";
		_command.CommandText = sql;
		_command.ExecuteNonQuery();

		_command.Dispose();
		//_command = null;
		_connection .Close();
		//_connection = null;

		}

	public void deactivateauto(Autos autodaten){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		
		_connection .Open();
		
		sql = "UPDATE AUTOS SET STATUS = '0' WHERE KENNZEICHEN = '"+autodaten.getKennzeichen ()+"'";
		_command.CommandText = sql;
		_command.ExecuteNonQuery();
		
		_command.Dispose();
		//_command = null;
		_connection .Close();
		//_connection = null;
		
	}

	public Autos getActiveAuto(){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT * FROM AUTOS WHERE STATUS='1' ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();

		_reader.Read ();
		Autos Auto=new Autos();
		Auto.setID (_reader ["ID"] as String);
		Auto.setKennzeichen(_reader ["KENNZEICHEN"] as String);
		Auto.setStatus (_reader ["STATUS"] as String);
		
		
		_command.Dispose();
		_connection .Close();
		_connection = null;
		_reader.Close();
		return Auto;
		}

}
