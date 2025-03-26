using Microsoft.AspNetCore.Mvc;
using Tasks.Module.DTOs;
using Tasks.Module.Model;
using Tasks.Module.Services.Interface;

namespace Tasks.Module.Handler
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service)
        {
            this._service = service;
        }
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetAllTask()
        {
            return Ok(await this._service.ListOfALlTask());
        }
        /// <summary>
        /// Create Task
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TaskModel>> CreateTask([FromBody] CreateTaskDTO body)
        {
            var task = await this._service.CreateTask(body);

            return CreatedAtAction(nameof(GetAllTask), new { id = task.Id }, task);
        }
        /// <summary>
        /// Get Task By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            return Ok(await this._service.FindTaskById(id));
        }
    }
}
