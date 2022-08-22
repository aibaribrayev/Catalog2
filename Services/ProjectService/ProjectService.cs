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
            //use serviceResponse Model to send response to request with Status, Message and Data fields
             var serviceResponse = new ServiceResponse<List<GetProjectDto>>();
             
            //mapping newProject of class <AddProjectDto> to project of class <Project>
             Project project = _mapper.Map<Project>(newProject); 
            

            //adding new project to DataContextv
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
                //search for the project that matches the id
                Project project = _context.Projects.First(t => t.Id == id);
                _context.Projects.Remove(project); 
                await _context.SaveChangesAsync();
                response.Data = _context.Projects.Select(t => _mapper.Map<GetProjectDto>(t)).ToList();
            } catch(Exception ex) { 
                //if no such project was found return response with null Data
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetAllProjects()
        {
            //creating response of class ServiceResponse with message, status and data fields
            var response = new ServiceResponse<List<GetProjectDto>>(); 
            //getting list of projects from context
            var dbProjects = await _context.Projects.ToListAsync();
            //mapping into Dto Class and saving as response data
            response.Data = dbProjects.Select(t => _mapper.Map<GetProjectDto>(t)).ToList(); 
            return response;
        }

        public async Task<ServiceResponse<GetProjectDto>> GetProjectById(int id)
        {
            var response = new ServiceResponse<GetProjectDto>();
            //finding project by id and returing it as response.Data
            var dbProject = await _context.Projects.FirstOrDefaultAsync (p => p.Id == id);
            response.Data = _mapper.Map<GetProjectDto>(dbProject);
            return response;
        }


        public async Task<ServiceResponse<List<GetProjectDto>>> GetProjectByName(string name)
        {
            var response = new ServiceResponse<List<GetProjectDto>>();
            //getting list of all projects 
            var dbProjects = await _context.Projects.ToListAsync();
            //filtering projects with the matching names
            var sortedProjects = dbProjects.Where(p => p.Name == name).ToList();
            response.Data = dbProjects.Select(t => _mapper.Map<GetProjectDto>(t)).ToList(); 
            return response;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetSortedByPriority()
        {
            var response = new ServiceResponse<List<GetProjectDto>>(); 
            //getting list of all projects from context
            var dbProjects = await _context.Projects.ToListAsync();
            var sortedProjects = dbProjects.OrderBy(p => p.Priority).ToList();
            response.Data = sortedProjects.Select(t => _mapper.Map<GetProjectDto>(t)).ToList(); 
            return response;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetSortedStart()
        {
            var response = new ServiceResponse<List<GetProjectDto>>(); 
            var dbProjects = await _context.Projects.ToListAsync();
            var sortedProjects = dbProjects.OrderBy(p => p.StartDate).ToList();
            response.Data = dbProjects.Select(t => _mapper.Map<GetProjectDto>(t)).ToList(); 
            return response;
        }

        public async Task<ServiceResponse<GetProjectDto>> UpdateProject(UpdateProjectDto updatedProject)
        {
            ServiceResponse<GetProjectDto> response = new ServiceResponse<GetProjectDto>();

            try{

                //finding project with the same Id as it is given in the body of put request
                var project = await _context.Projects
                    .FirstOrDefaultAsync(t => t.Id == updatedProject.Id);

                //updating all fields of project
                project.Name = updatedProject.Name; 
                project.Status = updatedProject.Status;
                project.Priority = updatedProject.Priority;
                project.StartDate = updatedProject.StartDate; 
                project.EndDate = updatedProject.EndDate; 
                await _context.SaveChangesAsync(); 

                response.Data = _mapper.Map<GetProjectDto>(project);  
            } catch(Exception ex) { 
                //if no matching projects found return response without Data field 
                response.Success = false; 
                response.Message = ex.Message; 
            }
            return response;
        }
    }
} 