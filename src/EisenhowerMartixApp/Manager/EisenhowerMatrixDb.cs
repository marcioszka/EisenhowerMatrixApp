using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace EisenhowerMatrixApp.src.EisenhowerMatrixApp.Manager
{
public class EisenhowerMatrixDb
{
    public string ConnectionString => ConfigurationManager.AppSettings["connectionString"];
    public void Connect()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        //Console.WriteLine($"Connected... {connection.ServerVersion}");
    }
}
}
