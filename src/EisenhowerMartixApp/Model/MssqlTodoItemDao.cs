using System.Data;
using System.Data.SqlClient;

namespace EisenhowerMatrixApp.src.EisenhowerMartixApp.Model
{
    public class MssqlTodoItemDao : ITodoItemDao
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
INSERT INTO item (title, deadline, is_done)
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
            throw new NotImplementedException();
        }

        public void Update(TodoItem todoItem)
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
                    WHERE id=@Id;
                    ";

                command.CommandText = updateTodoItemSql;
                command.Parameters.AddWithValue("@IsDone", todoItem.IsDone());
                command.Parameters.AddWithValue("@Id", todoItem.Id);

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                throw;
            }
        }

        public void Remove(int id)
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
                    WHERE id=@id;
                    ";

                command.CommandText = deleteTodoItemSql;
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                throw;
            }
        }
    }
}
