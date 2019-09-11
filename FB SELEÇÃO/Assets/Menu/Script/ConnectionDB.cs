using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public class ConnectionDB
{
    private static string server = "127.0.0.1";
    private static string database = "fbselect";
    private static string uid = "root";
    private static string password = "fbselect";


    public static MySqlConnection GetMysqlConnection()
    {
        MySqlConnection connection = null;

        try
        {
            string connectionString = "Server="+ server +";Database="+ database + ";Uid="+ uid + ";Pwd="+ password +";";
            connection = new MySqlConnection(connectionString);
            
        } catch (Exception e)
        {   
            Console.WriteLine(e.Message);
        }

        return connection;
    }
}