using AutoMapper;
using Catalog2.Data;
using Catalog2.DTOs.Task;
using Microsoft.EntityFrameworkCore;

namespace Catalog2.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TaskService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto newTask)
        {
             var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
             TaskItem task = _mapper.Map<TaskItem>(newTask); 
             _context.Tasks.Add(task); 
             await _context.SaveChangesAsync(); 
             serviceResponse.Data = await _context.Tasks
                .Select(t => _mapper.Map<GetTaskDto>(t))
                .ToListAsync(); 
             return serviceResponse; 
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id)
         {
            ServiceResponse<List<GetTaskDto>> response = new ServiceResponse<List<GetTaskDto>>();

            try{
                TaskItem task = _context.Tasks.First(t => t.Id == id);
                _context.Tasks.Remove(task); 
                await _context.SaveChangesAsync();
                
                response.Data = _context.Tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToList();
            } catch(Exception ex) { 
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks()
        {
            var response = new ServiceResponse<List<GetTaskDto>>(); 
            var dbTasks = await _context.Tasks.ToListAsync(); 
            response.Data = dbTasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToList(); 
            return response;
        }

        public async Task<ServiceResponse<GetTaskDto>> GetTaskById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTaskDto>();
            var dbTask = await _context.Tasks.FirstOrDefaultAsync (t => t.Id == id);
            serviceResponse.Data = _mapper.Map<GetTaskDto>(dbTask);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTaskDto>> UpdateTask(UpdateTaskDto updatedTask)
        {
            ServiceResponse<GetTaskDto> response = new ServiceResponse<GetTaskDto>();

            try{
                var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == updatedTask.Id);

                // _mapper.Map(updatedTask, task); 
                task.Name = updatedTask.Name; 
                task.Description = updatedTask.Description; 
                task.Class = updatedTask.Class;
                task.Priority = task.Priority;

                await _context.SaveChangesAsync(); 

                response.Data = _mapper.Map<GetTaskDto>(task);  
            } catch(Exception ex) { 
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }
    }
} 