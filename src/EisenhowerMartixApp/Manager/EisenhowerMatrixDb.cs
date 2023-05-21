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

        public void RemoveItemFromDB(ITodoItemDao itemDao, TodoItem todoItem)
        {
            
            itemDao.Remove(todoItem);
        }

        public void UpdateInDB(ITodoItemDao itemDao, TodoItem item)
        {
            itemDao.UpdateStatus(item);
        }

        public TodoMatrix FillPlannerWithDBItems(TodoMatrix matrix, ITodoItemDao itemDao)
        {
            var items = itemDao.GetAll();
            foreach (var item in items)
            {
                var title = item.GetTitle();
                var deadline = item.GetDeadline();
                var isDone = item.IsDone();
                var isImportant = item._isImportant;
                matrix.AddItem(title, deadline, isImportant, isDone);
            }
            return matrix;
        }

        public void ArchiveItemsInDB(ITodoItemDao itemDao)
        {
            itemDao.RemoveDone();
        }
    }
}
