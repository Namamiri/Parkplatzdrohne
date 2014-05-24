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
	public void createDatabase(){

		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;

		_connection .Open();

		//deleteTabelle ("Routenpunkte");

		if (abfrageexisttabelle ("Routenpunkte") == 0) {
			sql = "CREATE TABLE Routenpunkte (ID INT , Knotenname VARCHAR(55), XKOORD INT, YKOORD INT, TYPID INT, PRIMARY KEY(ID))";
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
			sql = "CREATE TABLE PARKPLATZ (PARKPLATZNUMMER INT, ROUTENID INT, FREI INT, KENNZEICHENFAHRZEUG VARCHAR(12), PRIMARY KEY(PARKPLATZNUMMER))";
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
		sql = "DROP TABLE "+Tabelle+" ";
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
