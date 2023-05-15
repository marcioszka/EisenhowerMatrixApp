using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp.src.EisenhowerMartixApp.Model
{
    internal class MssqlTodoItemDao : ITodoItemDao
    {
        private readonly string _connectionString;
        public MssqlTodoItemDao(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(TodoItem todoItem)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                string insertTodoItemSql =
                    @"
INSERT INTO eisenhower (title, deadline, is_done)
VALUES (@Title, @Deadline, @IsDone);

SELECT SCOPE_IDENTITY();
";

                command.CommandText = insertTodoItemSql;
                command.Parameters.AddWithValue("@Title", todoItem.GetTitle());
                command.Parameters.AddWithValue("@Deadline", todoItem.GetDeadline());
                command.Parameters.AddWithValue("@IsDone", todoItem.IsDone());

                int todoItemId = Convert.ToInt32(command.ExecuteScalar());
                todoItem.Id = todoItemId;
            }
            catch (SqlException exception)
            {
                throw;
            }
        }

        public TodoItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
