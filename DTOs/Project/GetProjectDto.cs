namespace Catalog2.DTOs.Project
{
    public class GetProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "project_name";

        public int Priority  {get; set;} 
        public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;

        // public List<TaskItem>? Tasks { get; set; }
    }
}