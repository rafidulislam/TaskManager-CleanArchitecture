using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connection;

        public TaskRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        // Get all tasks
        public async Task<List<TaskItem>> GetAllAsync()
        {
            var list = new List<TaskItem>();

            using var conn = new SqlConnection(_connection);
            var query = "SELECT Id, Title, IsCompleted FROM Tasks";

            using var cmd = new SqlCommand(query, conn);
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new TaskItem
                {
                    Id = (int)reader["Id"],
                    Title = reader["Title"].ToString(),
                    IsCompleted = (bool)reader["IsCompleted"]
                });
            }

            return list;
        }

        // Get a task by Id
        public async Task<TaskItem> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connection);
            var query = "SELECT Id, Title, IsCompleted FROM Tasks WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new TaskItem
                {
                    Id = (int)reader["Id"],
                    Title = reader["Title"].ToString(),
                    IsCompleted = (bool)reader["IsCompleted"]
                };
            }

            return null;
        }

        // Add a new task
        public async Task AddAsync(TaskItem task)
        {
            using var conn = new SqlConnection(_connection);
            var query = "INSERT INTO Tasks (Title, IsCompleted) VALUES (@Title, @IsCompleted)";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Title", task.Title);
            cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        // Update an existing task
        public async Task UpdateAsync(TaskItem task)
        {
            using var conn = new SqlConnection(_connection);
            var query = "UPDATE Tasks SET Title=@Title, IsCompleted=@IsCompleted WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", task.Id);
            cmd.Parameters.AddWithValue("@Title", task.Title);
            cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        // Delete a task by Id
        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connection);
            var query = "DELETE FROM Tasks WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
