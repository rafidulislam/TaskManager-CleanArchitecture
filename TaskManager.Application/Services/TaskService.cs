using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(TaskDto dto)
        {
            if (string.IsNullOrEmpty(dto.Title))
                throw new Exception("Title is required");

            var task = new TaskItem
            {
                Title = dto.Title,
                IsCompleted = false
            };

            await _repository.AddAsync(task);
        }

        public async Task UpdateAsync(UpdateTaskDto dto)
        {
            var task = new TaskItem
            {
                Id = dto.Id,
                Title = dto.Title,
                IsCompleted = dto.IsCompleted
            };

            await _repository.UpdateAsync(task);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
