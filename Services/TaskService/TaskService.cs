using AutoMapper;
using Catalog2.DTOs.Task;

namespace Catalog2.Services.TaskService
{
    public class TaskService : ITaskService
    {

         private static List<TaskItem> Tasks = new List<TaskItem>(){
            new TaskItem(),
            new TaskItem {Id = 1, Name = "Task1"}
        };
        private readonly IMapper mapper;

        public TaskService(IMapper mapper)
        {
            this.mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetTaskDto>>> AddItem(AddTaskDto newTask)
        {
             var ServiceResponse = new ServiceResponse<List<GetTaskDto>>();
             Tasks.Add(mapper.Map<TaskItem>(newTask)); 
             ServiceResponse.Data = Tasks.Select(t => mapper.Map<GetTaskDto>(t)).ToList(); 
             return ServiceResponse; 
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> GetAllItems()
        {
            return new ServiceResponse<List<GetTaskDto>>{Data = Tasks.Select(t => mapper.Map<GetTaskDto>(t)).ToList()};
        }

        public async Task<ServiceResponse<GetTaskDto>> GetItemById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTaskDto>();
            var task = Tasks.FirstOrDefault (t => t.Id == id);
            serviceResponse.Data = mapper.Map<GetTaskDto>(task);
            return serviceResponse;
        }
    }
}