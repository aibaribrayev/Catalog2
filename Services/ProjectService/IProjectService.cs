using Catalog2.DTOs.Project;

namespace Catalog2.Services.ProjectService
{
    public interface IProjectService
    {
        Task<ServiceResponse<List<GetProjectDto>>> GetAllProjects(); // get list of all projects
        Task<ServiceResponse<GetProjectDto>> GetProjectById(int id); //get specific project info
        Task<ServiceResponse<List<GetProjectDto>>> AddProject(AddProjectDto newProject);// add new project
        Task<ServiceResponse<GetProjectDto>> UpdateProject(UpdateProjectDto updatedProject);//modify existing project
        Task<ServiceResponse<List<GetProjectDto>>> DeleteProject(int id);//delete project 
        Task<ServiceResponse<List<GetProjectDto>>> GetSortedByPriority();//sorting projects by priority
        Task<ServiceResponse<List<GetProjectDto>>> GetSortedStart();//sorting projects by start
        Task<ServiceResponse<List<GetProjectDto>>> GetProjectByName(string name);//Filtering Projects by Name
    
    }
}