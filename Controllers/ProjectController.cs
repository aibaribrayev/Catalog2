using Catalog2.DTOs.Project;
using Catalog2.Services.ProjectService;
using Microsoft.AspNetCore.Mvc;


namespace Catalog2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        
        //returns All Projects
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> Get()
        {
            return  Ok(await projectService.GetAllProjects());
        }

        //returns project by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProjectDto>>> GetSingle(int id)
        {
            return Ok(await projectService.GetProjectById(id));
        }

        //returns list of projects sorted by priority
        [HttpGet("SortByPriority")]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> GetSortedByPriority()
        {
            return  Ok(await projectService.GetSortedByPriority());
        }
        //sorted list by Start date
        [HttpGet("SortByStartDate")]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> GetSortedStart()
        {
            return  Ok(await projectService.GetSortedStart());
        }

        //Filtering Projects by Name
        [HttpGet("FilterByName")]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> GetProjectByName(string name)
        {
            return  Ok(await projectService.GetProjectByName(name));
        }
        
        //Deleting project
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> Delete(int id)
        {
            var response = await projectService.DeleteProject(id);
            if(response.Data == null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //new project
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> AddProject(AddProjectDto newProject)
        {
            return Ok(await projectService.AddProject(newProject));
        }

        //updating project
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> UpdateProject(UpdateProjectDto updatedProject)
        {
            var response = await projectService.UpdateProject(updatedProject);
            if(response.Data == null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }


    }

}