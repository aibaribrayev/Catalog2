namespace Catalog2.DTOs.Project
{
    public class AddProjectDto
    {
        public string Name { get; set; } = "project_name"; 
        public int Priority  {get; set;} 
        public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;
        // public List<TasItem>? Tasks { get; set; }
    }
}