using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;
using System;
using System.Collections.Generic;

  
public class Database {
	string _strDBName = "URI=file:MasterSQLite.db";
	int StatusCar;
	int StatusDrone;
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

		return System.Convert.ToInt32(_reader["Count"]);


	}
	public int getanzahlfreeparkplaetze (){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT count(PARKPLATZNUMMER) as Count FROM PARKPLATZ WHERE FREI='1' ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		_reader.Read ();
		_connection .Close();
		_connection = null;
		int wert = System.Convert.ToInt32(_reader ["Count"]);
		_reader.Close();
		return wert;

		}
	public int getanzahlfreeparkplaetzelimit1 (){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT count(PARKPLATZNUMMER) as Count FROM PARKPLATZ WHERE FREI='1' ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		_reader.Read ();
		_connection .Close();
		_connection = null;
		int wert = System.Convert.ToInt32(_reader ["Count"]);
		_reader.Close();
		return wert;
		
	}
	public void filltableParkplatz(){

		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From PARKPLATZ";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();

		_connection.Close ();

		Parkplatz park = new Parkplatz ();

		for (int i=1; i<=46; i++) {
			String iasStr=System.Convert.ToString(i);
			RoutenPunkte Point= this.getRoutePointPKviaNumber(iasStr);
			park.setROUTENID (iasStr);park.setPARKPLATZNUMMER (iasStr);park.setXKOORD (System.Convert.ToString(Point.getX()));park.setZKOORD (System.Convert.ToString(Point.getZ()));this.addParkPlatz (park);
		}

	}

	public RoutenPunkte getRoutePointPKviaNumber(String ID){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT * FROM Routenpunkte WHERE Knotenname='PK"+ID+"' ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		RoutenPunkte point=new RoutenPunkte();
		_reader.Read ();
		point.setID(System.Convert.ToString(_reader["ID"]));
		point.setKNOTENNAME(System.Convert.ToString(_reader["Knotenname"]));
		point.setTYPID(System.Convert.ToString(_reader["TYPID"]));

		point.setX(System.Convert.ToString(_reader["XKOORD"]));
		point.setZ(System.Convert.ToString(_reader["ZKOORD"]));

		_command.Dispose ();
		_connection.Close ();

		return point;
		
	}

	void addParkPlatz(Parkplatz park){

		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection .Open();
		sql = "INSERT INTO PARKPLATZ (PARKPLATZNUMMER, ROUTENID, FREI, KENNZEICHENFAHRZEUG, XKOORD, ZKOORD) Values ("+park.getPARKPLATZNUMMER()+","+park.getROUTENID()+", 1,0,"+park.getX()+","+park.getZ()+")";
		_command.CommandText = sql;
		_command.ExecuteReader();

		_command.Dispose ();
		_connection.Close ();

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

	}

	public void fillTypPunkt(){
		Debug.Log ("fillTypPunkte");
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From TYPPUNKTE";
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
		sql = "INSERT INTO ROUTE (ROUTENID, POSITION, PUNKTID) Values ("+punkte.getRoutenID()+",'"+punkte.getPositionID()+"',"+punkte.getKnotenID()+")";
		_command.CommandText = sql;
		_command.ExecuteReader();
		
		_command.Dispose ();
		_connection.Close ();
		Debug.Log ("KnotenID " + punkte.getKnotenID() + " ; Position " + punkte.getPositionID()+" ; RoutenID: "+punkte.getRoutenID());
	}

	public Autos getAutoViaKennzeichen(String Kennzeichen){

		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT * FROM AUTOS WHERE KENNZEICHEN='"+Kennzeichen+"' ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();

		Autos auto = new Autos ();
		_reader.Read ();

		auto.setKennzeichen (System.Convert.ToString(_reader ["KENNZEICHEN"]));
		auto.setStatus (System.Convert.ToString(_reader ["STATUS"]));
		_command.Dispose ();
		_connection.Close ();
		return auto;

		}
	public void getParkplatzViaKennzeichencount(String Kennzeichen){
				IDbConnection _connection = new SqliteConnection (_strDBName);
				IDbCommand _command = _connection .CreateCommand ();
				string sql;
				IDataReader _reader;
				_connection .Open ();
				int i = 0;

				sql = "SELECT * FROM PARKPLATZ WHERE FREI='0' ";
				_command.CommandText = sql;
				_reader = _command.ExecuteReader ();
				while (_reader.Read ()){
			Debug.Log ("ParkplatzNummer " + _reader["PARKPLATZNUMMER"]+"   Kennzeichen   "+_reader["KENNZEICHENFAHRZEUG"]);
		}
		}
	public Parkplatz getParkplatzViaKennzeichen (String Kennzeichen){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT * FROM PARKPLATZ WHERE KENNZEICHENFAHRZEUG='"+Kennzeichen+"' ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();

		Parkplatz parkplatz = new Parkplatz ();
		_reader.Read ();
		parkplatz.setFREI(System.Convert.ToString(_reader["FREI"]));
		parkplatz.setPARKPLATZNUMMER(System.Convert.ToString(_reader["PARKPLATZNUMMER"]));
		parkplatz.setROUTENID(System.Convert.ToString(_reader["ROUTENID"]));
		parkplatz.setKENNZEICHEN(System.Convert.ToString(_reader["KENNZEICHENFAHRZEUG"]));
		parkplatz.setXKOORD(System.Convert.ToString(_reader["XKOORD"]));
		parkplatz.setZKOORD(System.Convert.ToString(_reader["ZKOORD"]));

		_command.Dispose ();
		_connection.Close ();
		return parkplatz;
		}

	public RouteContainer getRouteViaROUTEID (String RouteID){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT * FROM Route WHERE ROUTENID='"+RouteID+"' ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		RouteContainer container=new RouteContainer();
		while (_reader.Read()){
			Route Routeelement=new Route();
			Routeelement.setRoutenID(System.Convert.ToString(_reader["ROUTENID"]));
			Routeelement.setPositionID(System.Convert.ToString(_reader["POSITION"]));
			Routeelement.setKnotenID(System.Convert.ToString(_reader["PUNKTID"]));
			container.addRoute(Routeelement);
		}
		_command.Dispose ();
		_connection.Close ();

		return container;
		}

	public RoutenPunkte getRoutePointViaID(String ID){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT * FROM Routenpunkte WHERE ID='"+ID+"' ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		RoutenPunkte point=new RoutenPunkte();
		_reader.Read ();
		point.setID(System.Convert.ToString(_reader["ID"]));
		point.setKNOTENNAME(System.Convert.ToString(_reader["Knotenname"]));
		point.setTYPID(System.Convert.ToString(_reader["TYPID"]));
		point.setX(System.Convert.ToString(_reader["XKOORD"]));
		point.setZ(System.Convert.ToString(_reader["ZKOORD"]));
		_command.Dispose ();
		_connection.Close ();
		return point;

		}

	public void filltableRoute(){
		Debug.Log ("RoutePoints");
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From ROUTE";
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

		//20 Route
		PointstoRoute.setRoutenID ("20");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("20");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("33");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("20");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("34");this.addRoute (PointstoRoute);

		//21 Route
		PointstoRoute.setRoutenID ("21");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("21");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("35");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("21");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("36");this.addRoute (PointstoRoute);
		//22 Route
		PointstoRoute.setRoutenID ("22");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("22");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("35");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("22");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("37");this.addRoute (PointstoRoute);
		//23 Route
		PointstoRoute.setRoutenID ("23");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("23");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("38");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("23");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("39");this.addRoute (PointstoRoute);
		//24 Route
		PointstoRoute.setRoutenID ("24");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("24");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("38");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("24");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("40");this.addRoute (PointstoRoute);
		//25 Route
		PointstoRoute.setRoutenID ("25");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("25");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("41");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("25");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("42");this.addRoute (PointstoRoute);
		//26 Route
		PointstoRoute.setRoutenID ("26");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("26");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("41");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("26");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("43");this.addRoute (PointstoRoute);
		//27 Route
		PointstoRoute.setRoutenID ("27");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("27");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("44");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("27");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("45");this.addRoute (PointstoRoute);
		//28 Route
		PointstoRoute.setRoutenID ("28");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("28");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("44");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("28");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("46");this.addRoute (PointstoRoute);
		//29 Route
		PointstoRoute.setRoutenID ("29");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("29");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("47");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("29");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("48");this.addRoute (PointstoRoute);
		//30 Route
		PointstoRoute.setRoutenID ("30");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("30");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("47");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("30");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("49");this.addRoute (PointstoRoute);
		//31 Route
		PointstoRoute.setRoutenID ("31");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("31");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("50");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("31");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("51");this.addRoute (PointstoRoute);
		//32 Route
		PointstoRoute.setRoutenID ("32");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("32");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("50");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("32");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("52");this.addRoute (PointstoRoute);
		//33 Route
		PointstoRoute.setRoutenID ("33");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("33");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("53");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("33");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("54");this.addRoute (PointstoRoute);
		//34 Route
		PointstoRoute.setRoutenID ("34");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("32");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("34");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("53");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("34");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("55");this.addRoute (PointstoRoute);


		//35 Route
		PointstoRoute.setRoutenID ("35");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("35");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("57");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("35");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("58");this.addRoute (PointstoRoute);
		//36 Route
		PointstoRoute.setRoutenID ("36");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("36");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("57");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("36");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("59");this.addRoute (PointstoRoute);
		//37 Route
		PointstoRoute.setRoutenID ("37");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("37");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("60");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("37");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("61");this.addRoute (PointstoRoute);
		//38 Route
		PointstoRoute.setRoutenID ("38");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("38");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("60");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("38");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("62");this.addRoute (PointstoRoute);
		//39 Route
		PointstoRoute.setRoutenID ("39");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("39");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("63");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("39");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("64");this.addRoute (PointstoRoute);
		//40 Route
		PointstoRoute.setRoutenID ("40");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("40");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("63");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("40");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("65");this.addRoute (PointstoRoute);
		//41 Route
		PointstoRoute.setRoutenID ("41");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("41");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("66");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("41");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("67");this.addRoute (PointstoRoute);
		//42 Route
		PointstoRoute.setRoutenID ("42");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("42");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("66");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("42");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("68");this.addRoute (PointstoRoute);
		//43 Route
		PointstoRoute.setRoutenID ("43");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("43");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("69");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("43");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("70");this.addRoute (PointstoRoute);
		//44 Route
		PointstoRoute.setRoutenID ("44");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("44");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("69");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("44");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("71");this.addRoute (PointstoRoute);
		//45 Route
		PointstoRoute.setRoutenID ("45");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("45");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("72");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("45");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("73");this.addRoute (PointstoRoute);
		//46 Route
		PointstoRoute.setRoutenID ("46");PointstoRoute.setPositionID ("1");PointstoRoute.setKnotenID ("56");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("46");PointstoRoute.setPositionID ("2");PointstoRoute.setKnotenID ("72");this.addRoute (PointstoRoute);
		PointstoRoute.setRoutenID ("46");PointstoRoute.setPositionID ("3");PointstoRoute.setKnotenID ("74");this.addRoute (PointstoRoute);
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

		Punkt.setID ("56");Punkt.setKNOTENNAME ("FirstKnotL");Punkt.setX ("-4.642091"); Punkt.setZ ("-10.48455");Punkt.setTYPID("1");this.addRoutenPunkte (Punkt);

		Punkt.setID ("57");Punkt.setKNOTENNAME ("FrontPK35-PK36");Punkt.setX ("-4.642091"); Punkt.setZ ("-9.18896");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("58");Punkt.setKNOTENNAME ("PK35");Punkt.setX ("-3.707438"); Punkt.setZ ("-9.18896");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("59");Punkt.setKNOTENNAME ("PK36");Punkt.setX ("-6.395954"); Punkt.setZ ("-9.18896");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("60");Punkt.setKNOTENNAME ("FrontPK37-PK38");Punkt.setX ("-4.642091"); Punkt.setZ ("-8.533358");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("61");Punkt.setKNOTENNAME ("PK37");Punkt.setX ("-3.707438"); Punkt.setZ ("-8.533358");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("62");Punkt.setKNOTENNAME ("PK38");Punkt.setX ("-6.395954"); Punkt.setZ ("-8.533358");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("63");Punkt.setKNOTENNAME ("FrontPK39-PK40");Punkt.setX ("-4.642091"); Punkt.setZ ("-7.890867");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("64");Punkt.setKNOTENNAME ("PK39");Punkt.setX ("-3.707438"); Punkt.setZ ("-7.890867");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("65");Punkt.setKNOTENNAME ("PK40");Punkt.setX ("-6.395954"); Punkt.setZ ("-7.890867");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("66");Punkt.setKNOTENNAME ("FrontPK41-PK42");Punkt.setX ("-4.642091"); Punkt.setZ ("-7.261488");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("67");Punkt.setKNOTENNAME ("PK41");Punkt.setX ("-3.707438"); Punkt.setZ ("-7.261488");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("68");Punkt.setKNOTENNAME ("PK42");Punkt.setX ("-6.395954"); Punkt.setZ ("-7.261488");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("69");Punkt.setKNOTENNAME ("FrontPK43-PK44");Punkt.setX ("-4.642091"); Punkt.setZ ("-6.632109");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("70");Punkt.setKNOTENNAME ("PK43");Punkt.setX ("-3.707438"); Punkt.setZ ("-6.632109");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("71");Punkt.setKNOTENNAME ("PK44");Punkt.setX ("-6.395954"); Punkt.setZ ("-6.632109");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("72");Punkt.setKNOTENNAME ("FrontPK45-PK46");Punkt.setX ("-4.642091"); Punkt.setZ ("-5.989618");Punkt.setTYPID("2");this.addRoutenPunkte (Punkt);
		Punkt.setID ("73");Punkt.setKNOTENNAME ("PK45");Punkt.setX ("-3.707438"); Punkt.setZ ("-5.989618");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);
		Punkt.setID ("74");Punkt.setKNOTENNAME ("PK46");Punkt.setX ("-6.395954"); Punkt.setZ ("-5.989618");Punkt.setTYPID("3");this.addRoutenPunkte (Punkt);

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
	
		Punkt.setID ("75");Punkt.setKNOTENNAME ("ThirdKnot");Punkt.setX ("3.582275"); Punkt.setZ ("-11.58572");Punkt.setTYPID("1");this.addRoutenPunkte (Punkt);


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

		//deleteTabelle ("PARKPLATZ");

		if (abfrageexisttabelle ("PARKPLATZ") == 0) {
			sql = "CREATE TABLE PARKPLATZ (PARKPLATZNUMMER INT, ROUTENID INT, FREI INT, KENNZEICHENFAHRZEUG VARCHAR(12), XKOORD FLOAT, ZKOORD FLOAT, PRIMARY KEY(PARKPLATZNUMMER))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("PARKPLATZ Exists");
		}

		//deleteTabelle ("DRONEN");

		if (abfrageexisttabelle ("DRONEN") == 0) {
			sql = "CREATE TABLE DRONEN (DRONENNAME VARCHAR(50), AKTUELLERKNOTEN INT, LASTUSED DATE, HOMEPUNKTID INT, STATUS INT,CARTOSHOW VARCHAR(12),  PRIMARY KEY(DronenName))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("DRONEN Exists");
		}

		//deleteTabelle ("AUTOS");

		if (abfrageexisttabelle ("AUTOS") == 0) {
			sql = "CREATE TABLE AUTOS ( KENNZEICHEN VARCHAR(15), STATUS INT,  PRIMARY KEY(KENNZEICHEN))";
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
			platz.setPARKPLATZNUMMER(System.Convert.ToString(_reader["PARKPLATZNUMMER"]));
			platz.setFREI(System.Convert.ToString(_reader["FREI"]));
			platz.setKENNZEICHEN(System.Convert.ToString(_reader["KENNZEICHENFAHRZEUG"]));
			platz.setROUTENID(System.Convert.ToString(_reader["ROUTENID"] ));
			platz.setXKOORD(System.Convert.ToString(_reader["XKOORD"] ));
			platz.setZKOORD(System.Convert.ToString(_reader["ZKOORD"]));
			Liste.Add(platz);

				};

		
		_command.Dispose();
		_connection .Close();
		_connection = null;
		_reader.Close();
		return Liste;
	}

	public Parkplatz getfreeParkplatzlimit1(){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT * FROM PARKPLATZ WHERE FREI=1 LIMIT 1 ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();

		_reader.Read ();
			Parkplatz platz=new Parkplatz();
			platz.setPARKPLATZNUMMER(System.Convert.ToString(_reader["PARKPLATZNUMMER"]));
			platz.setFREI(System.Convert.ToString(_reader["FREI"]));
			platz.setKENNZEICHEN(System.Convert.ToString(_reader["KENNZEICHENFAHRZEUG"]));
			platz.setROUTENID(System.Convert.ToString(_reader["ROUTENID"] ));
			platz.setXKOORD(System.Convert.ToString(_reader["XKOORD"] ));
			platz.setZKOORD(System.Convert.ToString(_reader["ZKOORD"]));
			
			
	
		
		
		_command.Dispose();
		_connection .Close();
		_connection = null;
		_reader.Close();
		return platz;
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
		_connection.Dispose ();
		//_connection = null;
		Debug.Log (autodaten.getKennzeichen ());

		}
	public Parkplatz getrandomfreeparkandfillwithcar(String Carname){
		Autos auto = new Autos ();
		auto.setKennzeichen (Carname);
		auto.setStatus ("2");
		this.addauto (auto);
		List<Parkplatz> parkplaetze = this.getfreeParkplatz ();
		int anzahlfreierParkplaetze=parkplaetze.Count;
		Parkplatz gewaehlt;

		int wohin = UnityEngine.Random.Range (0, anzahlfreierParkplaetze-1);
		gewaehlt = parkplaetze [wohin];
		this.setStatusbesetztParkplatz (Carname, gewaehlt);
		return  gewaehlt;
		}
	public void deactivateauto(Autos autodaten){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		
		_connection .Open();
		
		sql = "UPDATE AUTOS SET STATUS = '2' WHERE KENNZEICHEN = '"+autodaten.getKennzeichen ()+"'";
		_command.CommandText = sql;
		_command.ExecuteNonQuery();
		
		_command.Dispose();
		//_command = null;
		_connection .Close();
		_connection.Dispose ();
		//_connection = null;
		
	}

	public Autos getActiveAuto(){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT * FROM AUTOS WHERE STATUS='1' Limit 1 ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();

		_reader.Read ();
		Autos Auto=new Autos();

		Auto.setKennzeichen(System.Convert.ToString(_reader ["KENNZEICHEN"]));
		Auto.setStatus (System.Convert.ToString(_reader ["STATUS"]));
		
		
		_command.Dispose();
		_connection .Close();
		_connection.Dispose ();
		_connection = null;
		_reader.Close();
		_reader.Dispose ();
		return Auto;
		}

	public void setStatusbesetztParkplatz(String Kennzeichen,Parkplatz pk){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		Debug.Log ("Parkplatznummer in setStatusbesetztParkplatz " + pk.getPARKPLATZNUMMER ()+ "  Kennzeichen   " + Kennzeichen);
		_connection .Open();

		sql = "UPDATE PARKPLATZ SET FREI = '0', KENNZEICHENFAHRZEUG = '"+Kennzeichen+"'  WHERE PARKPLATZNUMMER = "+pk.getPARKPLATZNUMMER();
		_command.CommandText = sql;
		_command.ExecuteNonQuery();
		
		_command.Dispose();
		//_command = null;
		_connection .Close();
		_connection.Dispose ();
		//_connection = null;
		}
	public Autos getrandomparkingcar(){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT Count(KENNZEICHEN) as COUNT FROM AUTOS WHERE STATUS='2' ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		_reader.Read ();
		int zufall = UnityEngine.Random.Range (1, System.Convert.ToInt32(_reader ["COUNT"]));
		_reader.Close ();
		sql = "SELECT * FROM AUTOS WHERE STATUS = '2' LIMIT "+ zufall;
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		for (int i=0; i<zufall; i++) {
			_reader.Read();
				}
		Autos car = new Autos ();
		Debug.Log (_reader ["KENNZEICHEN"]);
		car.setKennzeichen (System.Convert.ToString (_reader ["KENNZEICHEN"]));
		car.setStatus("2");
		_command.Dispose();
		//_command = null;
		_connection .Close();
		_connection.Dispose ();
		//_connection = null;
		_reader.Close ();
		_reader.Dispose ();
		return car;
		}
	// AutoStatus wird auf 3 Gesetzt Damit der 3th Script innerhalb der CarKomponenten aktiviert wird
	public void setcartoleave(String Kennzeichen){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		
		_connection .Open();
		
		sql = "UPDATE AUTOS SET STATUS = '3' WHERE KENNZEICHEN = '"+Kennzeichen+"'";
		_command.CommandText = sql;
		_command.ExecuteNonQuery();

		_command.Dispose();
		//_command = null;
		_connection .Close();
		_connection.Dispose ();
		//_connection = null;
		}
	// Diese Funktion übernimmt die Dtenbankeinträge beim Einchecken gleichzeitig wird überprüft ob noch Parkplätze frei sind
	public bool einchecken(String CarKennzeichen){
		int anzahlfreeparkplatz = this.getanzahlfreeparkplaetzelimit1 ();

		if (anzahlfreeparkplatz == 0) {
				return false;
				}
		else
			{
				Autos auto = new Autos ();
				auto.setKennzeichen (CarKennzeichen);
				auto.setStatus ("1");
				this.addauto (auto);
				Parkplatz park = this.getfreeParkplatzlimit1 ();
				
				this.setStatusbesetztParkplatz (CarKennzeichen,park);
				return true;
			}
		}
	// Hier wird ein auto gelöscht
	public void deletecar(String Kennzeichen){
		Debug.Log ("delete Car");
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From AUTOS WHERE KENNZEICHEN= '"+Kennzeichen+"'";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		
		_connection.Close ();
		_connection.Dispose ();
		_command.Dispose();
	}
	public bool getifactiveCarExists(){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT COUNT(KENNZEICHEN) AS Count FROM AUTOS WHERE STATUS='1' Limit 1 ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		
		_reader.Read ();

		if (0 < System.Convert.ToInt32 (_reader ["Count"])) 
		{	_command.Dispose();
			_connection .Close();
			_connection.Dispose();
			_connection = null;
			_reader.Close();
			_reader.Dispose();
			return true;
				}
		else{
			_command.Dispose();
			_connection .Close();
			_connection.Dispose();
			_connection = null;
			_reader.Close();
			_reader.Dispose();
			return false;
		}
		
		
		_command.Dispose();
		_connection .Close();
		_connection.Dispose ();
		_connection = null;
		_reader.Close();
		_reader.Dispose ();
	
		}
	public void allesaufanfang(){
		Debug.Log ("delete Car");
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From AUTOS ";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();

		sql=" UPDATE PARKPLATZ SET KENNZEICHENFAHRZEUG='', FREI='1' WHERE FREI='0'";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		_command.Dispose();
		_connection .Close();
		_connection.Dispose ();
		_connection = null;
		}

	public void fillTableDronen(){
		Debug.Log ("Dronen");
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		_connection.Open();
		sql = " Delete From DRONEN";
		_command.CommandText = sql;
		_command.ExecuteNonQuery ();
		
		_connection.Close ();
		_command.Dispose ();
		_connection.Dispose ();
		Drone drone = new Drone ();
		drone.setName ("QuadCopter");drone.setStatus ("0");this.addDrone (drone);
		}
	public void addDrone (Drone drone){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		
		_connection .Open();
		
		sql = "INSERT INTO DRONEN (DRONENNAME,AKTUELLERKNOTEN,HOMEPUNKTID, STATUS,CARTOSHOW) Values ('"+ drone.getName()+"','2','2','0','ef')";
		_command.CommandText = sql;
		_command.ExecuteNonQuery();
		
		_command.Dispose();
		//_command = null;
		_connection .Close();
		_connection.Dispose ();
		//_connection = null;
		}
	public void UpdateStatusDrone(String Name,String Status){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		
		_connection .Open();
	
		sql = "UPDATE DRONEN SET STATUS = '"+Status+"' WHERE DRONENNAME = '"+Name+"'";
		_command.CommandText = sql;
		_command.ExecuteNonQuery();
		
		_command.Dispose();
		//_command = null;
		_connection .Close();
		_connection.Dispose ();
		//_connection = null;
		}
	public int getStatusDrone(String Name){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT STATUS FROM DRONEN WHERE DRONENNAME = '"+Name+"' Limit 1 ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		
		_reader.Read ();
		StatusDrone = System.Convert.ToInt32 (_reader ["STATUS"]);
		_command.Dispose();
		//_command = null;
		_connection .Close();
		_connection.Dispose ();
		//_connection = null;
		_reader.Close ();
		_reader.Dispose ();
		return StatusDrone;
		}
	public int stateofcar(String Kennzeichen){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();

		sql = "SELECT STATUS FROM AUTOS WHERE KENNZEICHEN = '"+Kennzeichen+"' Limit 1 ";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		
		_reader.Read ();
		StatusCar = System.Convert.ToInt32 (_reader ["STATUS"]);
		_reader.Close ();
		_reader.Dispose ();
		_command.Dispose();
		//_command = null;
		_connection .Close();
		//_connection = null;
		return StatusCar;

		}
}
