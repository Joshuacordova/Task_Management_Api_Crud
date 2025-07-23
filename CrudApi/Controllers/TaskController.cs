using CrudApi.Models.Dtos;
using CrudApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;

namespace CrudApi.Controllers
{
    [RoutePrefix("api/task")]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IHttpActionResult> GetAll(int pageNumber, int pageSize)
        {
            return Ok(await _taskService.GetAllTasks(pageNumber, pageSize));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IHttpActionResult> GetById(int Id)
        {
            return Ok(await _taskService.GetTaskById(Id));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IHttpActionResult> Create([FromBody] CreateTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _taskService.CreateTask(dto);
            return Ok("Successfully saved");
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IHttpActionResult> Update([FromBody] UpdateTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _taskService.UpdateTask(dto);
            return Ok("Successfully saved");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(int Id)
        {
            await _taskService.DeleteTask(Id);
            return Ok("Successfully deleted");
        }

        [HttpGet]
        [Route("GetAllByStatus")]
        public async Task<IHttpActionResult> GetAllByStatus(int status, int pageNumber, int pageSize)
        {
            return Ok(await _taskService.GetTasksByStatus(status, pageNumber, pageSize));
        }

        [HttpGet]
        [Route("GetByStatus")]
        public async Task<IHttpActionResult> GetByStatus(int status)
        {
            return Ok(await _taskService.GetTaskByStatus(status));
        }
    }
}