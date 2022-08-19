using AutoMapper;
using Catalog2.DTOs.Task;

namespace Catalog2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        { 
            CreateMap<TaskItem, GetTaskDto>(); 
            CreateMap<AddTaskDto, TaskItem>(); 
            CreateMap<UpdateTaskDto, Task>();  
        }

        


    }
}