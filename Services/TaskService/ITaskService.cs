using Catalog2.DTOs.Task;

namespace Catalog2.Services.TaskService
{
    public interface ITaskService
    {
        Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks(); 
        Task<ServiceResponse<GetTaskDto>> GetTaskById(int id); 
        Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto newTask);
        Task<ServiceResponse<GetTaskDto>> UpdateTask(UpdateTaskDto updateDto);
        Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id);
    }
} 