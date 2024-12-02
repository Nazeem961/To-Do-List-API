using Microsoft.Data.SqlClient;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddTask(string title, bool status)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO List (Title, Status) VALUES (@title, @status)", connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@status", status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ToDoItem> GetTasks()
        {
            List<ToDoItem> tasks = new List<ToDoItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM List", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Using a constructor to initialize the read-only Id property
                            tasks.Add(new ToDoItem(
                                id: (int)reader["Id"],
                                title: (string)reader["Title"],
                                status: (bool)reader["Status"]
                            ));
                        }
                    }
                }
            }
            return tasks;
        }

        public ToDoItem GetTaskById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM List WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ToDoItem(
                                id: (int)reader["Id"],
                                title: (string)reader["Title"],
                                status: (bool)reader["Status"]
                            );
                        }
                    }
                }
            }
            return null;
        }

        public void UpdateTask(int id, string title, bool status)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE List SET Title = @title, Status = @status WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@status", status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTask(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM List WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
