using Catalog2.DTOs.Task;
using Catalog2.Services.TaskService;
using Microsoft.AspNetCore.Mvc;


namespace Catalog2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTaskDto>>>> Get()
        {
            return  Ok(await taskService.GetAllTasks());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTaskDto>>> GetSingle(int id)
        {
            return Ok(await taskService.GetTaskById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetTaskDto>>>> Delete(int id)
        {
            var response = await taskService.DeleteTask(id);
            if(response.Data == null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTaskDto>>>> AddTask(AddTaskDto newTask)
        {
            return Ok(await taskService.AddTask(newTask));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTaskDto>>>> UpdateTask(UpdateTaskDto updatedTask)
        {
            var response = await taskService.UpdateTask(updatedTask);
            if(response.Data == null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}