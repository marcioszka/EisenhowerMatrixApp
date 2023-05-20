using EisenhowerMatrixApp.src.EisenhowerMartixApp.Model;
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

        public void AddItemToDB(ITodoItemDao itemDao, string title, DateTime deadline, bool isImportant)
        {
            TodoItem item = new TodoItem(title, deadline);
            itemDao.Add(item, isImportant);
        }

        public void RemoveItemFromDB(ITodoItemDao itemDao, int index)
        {
            itemDao.Remove(index);
        }

        public void UpdateInDB(ITodoItemDao itemDao, TodoItem item)
        {
            itemDao.UpdateStatus(item);
        }
    }
}
