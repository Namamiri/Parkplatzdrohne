﻿using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;
using System;
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
	object abfrageexisttabelle(string Tabellenname){
		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;
		IDataReader _reader;
		_connection .Open();
		sql = "SELECT count(name) as Count FROM sqlite_master WHERE type='table' AND name='Routenpunkte"+Tabellenname+"'";
		_command.CommandText = sql;
		_reader = _command.ExecuteReader();
		_reader.Read ();
		_connection .Close();
		_connection = null;
		_reader.Close();
		return _reader["Count"];

	}
	public void createDatabase(){

		IDbConnection _connection = new SqliteConnection(_strDBName);
		IDbCommand _command = _connection .CreateCommand();
		string sql;

		_connection .Open();

		if (abfrageexisttabelle ("Routenpunkte").Equals ("0")) {
						sql = "CREATE TABLE Routenpunkte (ID INT, XKOORD INT, YKOORD INT, TYPID INT, PRIMARY KEY(ID))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery ();
				} else {
			Debug.Log("Routenpunkte Exists");
				}
		if (abfrageexisttabelle ("TYPPUNKTE").Equals ("0")) {
						sql = "CREATE TABLE TYPPUNKTE (ID INT, TYPBEZEICHNUNG VARCHAR(55), PRIMARY KEY(ID))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("TYPPUNKTE Exists");
		}
		if (abfrageexisttabelle ("ROUTE").Equals ("0")) {
						sql = "CREATE TABLE ROUTE (ROUTENID INT, POSITION INT, PUNKTID INT, PRIMARY KEY(ROUTENID, POSITION))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("ROUTE Exists");
		}
		if (abfrageexisttabelle ("PARKPLATZ").Equals ("0")) {
						sql = "CREATE TABLE PARKPLATZ (PARKPLATZNUMMER INT, ROUTENID INT, FREI INT, KENNZEICHENFAHRZEUG VARCHAR(12), PRIMARY KEY(PARKPLATZNUMMER))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("PARKPLATZ Exists");
		}
		if (abfrageexisttabelle ("DRONEN").Equals ("0")) {
						sql = "CREATE TABLE DRONEN (ID INT, AKTUELLERKNOTEN INT, LASTUSED DATE, HOMEPUNKT ID, PRIMARY KEY(ID))";
						_command.CommandText = sql;
						_command.ExecuteNonQuery();
		} else {
			Debug.Log("DRONEN Exists");
		}

		_command.Dispose();
		//_command = null;
		_connection .Close();
		//_connection = null;
	}
}