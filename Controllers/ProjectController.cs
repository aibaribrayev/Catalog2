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
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> Get()
        {
            return  Ok(await projectService.GetAllProjects());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProjectDto>>> GetSingle(int id)
        {
            return Ok(await projectService.GetProjectById(id));
        }

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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> AddProject(AddProjectDto newProject)
        {
            return Ok(await projectService.AddProject(newProject));
        }

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