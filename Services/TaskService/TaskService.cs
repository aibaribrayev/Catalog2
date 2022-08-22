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
             var response = new ServiceResponse<List<GetTaskDto>>();
             try{ 
                Project project = _context.Projects
                    .First(p => p.Id == newTask.projectId);
    
                TaskItem task = _mapper.Map<TaskItem>(newTask);
                task.InProject = project; 
                _context.Tasks.Add(task); 
                await _context.SaveChangesAsync(); 

                 //if the Project with Id was found, let response.Data
                 //be the list of all Tasks in the given Project. 
                var dbTasks = await _context.Tasks
                    .Where(t => t.projectId == newTask.projectId)
                    .ToListAsync(); 

                response.Data = dbTasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToList(); 
            
             } catch(Exception ex) { 
                // if the projcet with given Id was not found
                //return response with Error Message and null Data field
                response.Success = false; 
                response.Message = ex.Message; 
             }
            return response;
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id)
         {
            ServiceResponse<List<GetTaskDto>> response = new ServiceResponse<List<GetTaskDto>>();

            try{
                //search for the task by Id
                TaskItem task = _context.Tasks.First(t => t.Id == id);
                _context.Tasks.Remove(task); 
                await _context.SaveChangesAsync();
                
                response.Data = _context.Tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToList();
            } catch(Exception ex) { 
                //return response with null data field if no matching task was founded
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }


        //getting all tasks in the Project
        public async Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks(int projectId)
        {
            var response = new ServiceResponse<List<GetTaskDto>>();

            var dbTasks = await _context.Tasks
                .Where(t => t.projectId == projectId)
                .ToListAsync(); 
            //returing tasks that belong to the corresponding project in response.Data as DTO onjects
            response.Data = dbTasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToList(); 
            return response;
        }

        public async Task<ServiceResponse<GetTaskDto>> GetTaskById(int id)
        {
            var response = new ServiceResponse<GetTaskDto>();
            var dbTask = await _context.Tasks.FirstOrDefaultAsync (t => t.Id == id);
            response.Data = _mapper.Map<GetTaskDto>(dbTask);
            return response;
        }

        public async Task<ServiceResponse<GetTaskDto>> UpdateTask(UpdateTaskDto updatedTask)
        {
            ServiceResponse<GetTaskDto> response = new ServiceResponse<GetTaskDto>();

            try{
                //find the task with the matching id
                var task = await _context.Tasks
                    .FirstOrDefaultAsync(t => t.Id == updatedTask.Id);

                //updating fields of the Task
                task.Name = updatedTask.Name; 
                task.Description = updatedTask.Description; 
                task.Class = updatedTask.Class;
                task.Priority = updatedTask.Priority; 
                      
                //if the projectId field of the task is changed, 
                //we must also update Inproject field 
                if (updatedTask.projectId != 0 && updatedTask.projectId != task.projectId) {
                    task.projectId = updatedTask.projectId; 
                    Project project = _context.Projects
                        .First(p => p.Id == task.projectId);
                    task.InProject = project; 
                }
                await _context.SaveChangesAsync(); 

                response.Data = _mapper.Map<GetTaskDto>(task);  
            } catch(Exception ex) { 
                //if no matching tasks were found return response with null Data field 
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }
    }
} 