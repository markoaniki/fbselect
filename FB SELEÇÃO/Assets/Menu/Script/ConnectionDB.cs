using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public class ConnectionDB
{
    private static string server = "191.237.252.140";
    private static string database = "fbselect";
    private static string uid = "fbselect";
    private static string password = "v#Y9Gap&i3r";


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