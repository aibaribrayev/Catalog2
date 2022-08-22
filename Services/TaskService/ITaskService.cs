using Catalog2.DTOs.Task;

namespace Catalog2.Services.TaskService
{
    public interface ITaskService
    {
        Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks(int ProjectKey); //returns all tasks in the project with the given Id
        Task<ServiceResponse<GetTaskDto>> GetTaskById(int id); //returns single task by its ID
        Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto newTask);//adding new task 
        Task<ServiceResponse<GetTaskDto>> UpdateTask(UpdateTaskDto updateDto);//Updating task data
        Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id);//Deleting a task 
    }
} 