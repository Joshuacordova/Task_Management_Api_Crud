using AutoMapper;
using CrudApi.Infrastructure;
using CrudApi.Infrastructure.Enums;
using CrudApi.Models;
using CrudApi.Models.Dtos;
using CrudApi.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CrudApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository<TaskModel> _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository<TaskModel> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new task with the provided details.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task CreateTask(CreateTaskDto task)
        {
            if (string.IsNullOrEmpty(task.Title))
                throw new BadRequestException("Title cannot be empty.");

            var result = await _taskRepository.GetAll();
            if (result.Any(x => x.Title.Equals(task.Title)))
                throw new BadRequestException("Duplicate title");

            //use auto mapper
            var model = _mapper.Map<TaskModel>(task);

            await _taskRepository.Create(model);
        }

        /// <summary>
        /// Deletes a task by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteTask(int id)
        {
            await _taskRepository.Delete(new TaskModel { Id = id });
        }
        /// <summary>
        /// Retrieves all tasks with pagination support.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskModel>> GetAllTasks(int pageNumber, int pageSize)
        {
            //for pagination
            var result = await _taskRepository.GetAll();
            return result.Skip(pageNumber).Take(pageSize).ToList();
        }

        /// <summary>
        ///     Retrieves a task by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _taskRepository.GetById(id);
        }

        /// <summary>
        /// Retrieves a task by its status.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<TaskModel> GetTaskByStatus(int status)
        {
            return await _taskRepository.GetByStatus(status);
        }
        /// <summary>
        /// Retrieves tasks by their status with pagination support.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskModel>> GetTasksByStatus(int status, int pageNumber, int pageSize)
        {
            var result = await _taskRepository.GetAll();
            return result.Where(x => x.Status == status).Skip(pageNumber);
        }

        /// <summary>
        /// Updates an existing task with the provided details.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateTask(UpdateTaskDto task)
        {
            if (string.IsNullOrEmpty(task.Title))
                throw new BadRequestException("Title cannot be empty.");
            var result = await _taskRepository.GetById(task.Id);

            if(result == null)
                throw new BadRequestException("Record not found");
            //use auto mapper
            var model = _mapper.Map<TaskModel>(task);

            await _taskRepository.Update(model);
        }
    }
}