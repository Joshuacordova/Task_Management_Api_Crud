using CrudApi.Models;
using CrudApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetAllTasks(int pageNumber, int pageSize);
        Task<TaskModel> GetTaskById(int id);
        Task CreateTask(CreateTaskDto task);
        Task UpdateTask(UpdateTaskDto task);
        Task DeleteTask(int id);
        Task<TaskModel> GetTaskByStatus(int status);
        Task<IEnumerable<TaskModel>> GetTasksByStatus(int status, int pageNumber, int pageSize);
    }
}
