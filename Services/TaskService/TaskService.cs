using AutoMapper;
using Catalog2.DTOs.Task;

namespace Catalog2.Services.TaskService
{
    public class TaskService : ITaskService
    {

         private static List<TaskItem> tasks = new List<TaskItem>(){
            new TaskItem(),
            new TaskItem {Id = 1, Name = "Task1"}
        };
        private readonly IMapper _mapper;

        public TaskService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto newTask)
        {
             var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
             TaskItem task = _mapper.Map<TaskItem>(newTask); 
             task.Id = tasks.Max(t => t.Id) + 1; 
             tasks.Add(task); 
             serviceResponse.Data = tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToList(); 
             return serviceResponse; 
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id)
         {
            ServiceResponse<List<GetTaskDto>> response = new ServiceResponse<List<GetTaskDto>>();

            try{
                TaskItem task = tasks.First(t => t.Id == id);
                tasks.Remove(task); 
                response.Data = tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToList();
            } catch(Exception ex) { 
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks()
        {
            return new ServiceResponse<List<GetTaskDto>>{Data = tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToList()};
        }

        public async Task<ServiceResponse<GetTaskDto>> GetTaskById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTaskDto>();
            var task = tasks.FirstOrDefault (t => t.Id == id);
            serviceResponse.Data = _mapper.Map<GetTaskDto>(task);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTaskDto>> UpdateTask(UpdateTaskDto updatedTask)
        {
            ServiceResponse<GetTaskDto> response = new ServiceResponse<GetTaskDto>();

            try{
                TaskItem task = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);

                // _mapper.Map(updatedTask, task); 
                task.Name = updatedTask.Name; 
                task.Description = updatedTask.Description; 
                task.Class = updatedTask.Class;
                task.Priority = task.Priority;

                response.Data = _mapper.Map<GetTaskDto>(task);  
            } catch(Exception ex) { 
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }
    }
} 