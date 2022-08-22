using AutoMapper;
using Catalog2.DTOs.Project;
using Catalog2.DTOs.Task;

namespace Catalog2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        { 
            //maps for converting between DTOs and Models 
            CreateMap<TaskItem, GetTaskDto>(); 
            CreateMap<AddTaskDto, TaskItem>();
            CreateMap<Project, GetProjectDto>();
            CreateMap<AddProjectDto, Project>();
            // CreateMap<UpdateTaskDto, TaskItem>();  
        }

        


    }
}