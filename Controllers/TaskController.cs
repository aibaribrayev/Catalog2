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
            return  Ok(await taskService.GetAllItems());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTaskDto>>> GetSingle(int id)
        {
            return Ok(await taskService.GetItemById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTaskDto>>>> AddItem(AddTaskDto newTask)
        {
            return Ok(await taskService.AddItem(newTask));
        }
    }
}