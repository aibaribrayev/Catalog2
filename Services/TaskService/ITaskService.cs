using Catalog2.DTOs.Task;

namespace Catalog2.Services.TaskService
{
    public interface ITaskService
    {
        Task<ServiceResponse<List<GetTaskDto>>> GetAllItems(); 
        Task<ServiceResponse<GetTaskDto>> GetItemById(int id); 
        Task<ServiceResponse<List<GetTaskDto>>> AddItem(AddTaskDto newTask);
    }
} 