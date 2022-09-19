using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;

public class SimpleDB : MonoBehaviour
{
    private string dbname = "URI=file:Inventory.db";

    private void Start()
    {
        CreateDB();
        //AddWeapon("novi gun", 6);
        //AddWeapon("drugi gun", 41);
        //AddWeapon("lorem ipsum", 2);

        DisplayWeapons();
    }

    private void CreateDB()
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS weapons (name VARCHAR(20), damage INT);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    private void AddWeapon(string weaponName, int weaponDamage)
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO weapons (name, damage) VALUES ('" + weaponName + "', '" + weaponDamage + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void DisplayWeapons()
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM weapons;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name " + reader["name"] + "\tDamage: " + reader["damage"]);
                    }
                    reader.Close();
                }
                connection.Close();
            }
        }
    }
}
