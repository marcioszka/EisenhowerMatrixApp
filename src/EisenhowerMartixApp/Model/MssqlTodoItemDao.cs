﻿using System.Data;
using Microsoft.Data.SqlClient;

namespace EisenhowerMatrixApp.src.EisenhowerMartixApp.Model
{
    public class MssqlTodoItemDao : ITodoItemDao
    {
        private readonly string _connectionString;

        public MssqlTodoItemDao(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(TodoItem todoItem, bool isImportant)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                string insertTodoItemSql =
                    @"
INSERT INTO item (title, deadline, is_done, is_important)
VALUES (@Title, @Deadline, @IsDone, @IsImportant);

SELECT SCOPE_IDENTITY();
";

                command.CommandText = insertTodoItemSql;
                command.Parameters.AddWithValue("@Title", todoItem.GetTitle());
                command.Parameters.AddWithValue("@Deadline", todoItem.GetDeadline());
                command.Parameters.AddWithValue("@IsDone", todoItem.IsDone());
                command.Parameters.AddWithValue("@IsImportant", isImportant);

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
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                string selectTodoItemSql =
                    @"
                    SELECT title, deadline, is_done FROM item
                    WHERE id=@Id;
                    ";

                command.CommandText = selectTodoItemSql;
                command.Parameters.AddWithValue("@Id", id);

                using var reader = command.ExecuteReader();
                TodoItem item = null;

                if (reader.Read())
                {
                    string title = (string)reader["title"];
                    DateTime deadline = Convert.ToDateTime(reader["deadline"]);
                    bool isDone = (bool)reader["is_done"];
                    //bool isImportant = (bool)reader["is_important"];

                    item = new TodoItem(title, deadline, isDone);
                    item.Id = id;
                }

                return item;
            }
            catch (SqlException exception)
            {
                throw;
            }
        }

        public List<TodoItem> GetAll()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                string selectTodoItemSql =
                    @"
                    SELECT title, deadline, is_done, is_important FROM item;
                    ";

                command.CommandText = selectTodoItemSql;

                using var reader = command.ExecuteReader();
                var itemsList = new List<TodoItem>();

                while (reader.Read())
                {
                    string title = (string)reader["title"];
                    DateTime deadline = Convert.ToDateTime(reader["deadline"]);
                    byte isDoneByte = reader.GetByte("is_done");
                    bool isDone = isDoneByte == 1;
                    byte isImportantByte = reader.GetByte("is_important");
                    bool isImportant = isImportantByte == 1;

                    var item = new TodoItem(title, deadline, isDone) { _isImportant = isImportant };

                    itemsList.Add(item);
                }

                return itemsList;
            }
            catch (SqlException exception)
            {
                throw;
            }
        }

        public void UpdateStatus(TodoItem todoItem)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                string updateTodoItemSql =
                    @"
                    UPDATE item
                    SET is_done = @IsDone
                    WHERE title=@Title AND deadline=@Deadline;
                    ";

                var isDone = todoItem.IsDone() ? 1 : 0;

                command.CommandText = updateTodoItemSql;
                command.Parameters.AddWithValue("@IsDone", isDone);
                command.Parameters.AddWithValue("@Title", todoItem.GetTitle());
                command.Parameters.AddWithValue("@Deadline", todoItem.GetDeadline());

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                throw;
            }
        }

        public void Remove(TodoItem todoItem)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                string deleteTodoItemSql =
                    @"
                    DELETE FROM item
                    WHERE title=@Title AND deadline=@Deadline;
                    ";

                command.CommandText = deleteTodoItemSql;
                command.Parameters.AddWithValue("@Title", todoItem.GetTitle());
                command.Parameters.AddWithValue("@Deadline", todoItem.GetDeadline());

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                throw;
            }
        }
    }
}
