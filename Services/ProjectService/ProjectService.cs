using AutoMapper;
using Catalog2.Data;
using Catalog2.DTOs.Project;
using Microsoft.EntityFrameworkCore;

namespace Catalog2.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProjectService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<ServiceResponse<List<GetProjectDto>>> AddProject(AddProjectDto newProject)
        {
             var serviceResponse = new ServiceResponse<List<GetProjectDto>>();
             Project project = _mapper.Map<Project>(newProject); 
             _context.Projects.Add(project); 
             await _context.SaveChangesAsync(); 
             serviceResponse.Data = await _context.Projects
                .Select(t => _mapper.Map<GetProjectDto>(t))
                .ToListAsync(); 
             return serviceResponse; 
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> DeleteProject(int id)
         {
            ServiceResponse<List<GetProjectDto>> response = new ServiceResponse<List<GetProjectDto>>();

            try{
                Project project = _context.Projects.First(t => t.Id == id);
                _context.Projects.Remove(project); 
                await _context.SaveChangesAsync();
                
                response.Data = _context.Projects.Select(t => _mapper.Map<GetProjectDto>(t)).ToList();
            } catch(Exception ex) { 
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetAllProjects()
        {
            var response = new ServiceResponse<List<GetProjectDto>>(); 
            var dbProjects = await _context.Projects.ToListAsync(); 
            response.Data = dbProjects.Select(t => _mapper.Map<GetProjectDto>(t)).ToList(); 
            return response;
        }

        public async Task<ServiceResponse<GetProjectDto>> GetProjectById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProjectDto>();
            var dbProject = await _context.Projects.FirstOrDefaultAsync (t => t.Id == id);
            serviceResponse.Data = _mapper.Map<GetProjectDto>(dbProject);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProjectDto>> UpdateProject(UpdateProjectDto updatedProject)
        {
            ServiceResponse<GetProjectDto> response = new ServiceResponse<GetProjectDto>();

            try{
                var project = await _context.Projects
                .FirstOrDefaultAsync(t => t.Id == updatedProject.Id);

                project.Name = updatedProject.Name; 
                project.Status = updatedProject.Status;
                project.Priority = project.Priority;

                await _context.SaveChangesAsync(); 

                response.Data = _mapper.Map<GetProjectDto>(project);  
            } catch(Exception ex) { 
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }
    }
} 