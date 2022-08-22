namespace Catalog2.DTOs.Project
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "project_name"; 
        public int? Priority  {get; set;} 
        public ProjectStatus? Status { get; set; } = ProjectStatus.NotStarted;

        public DateTime? StartDate { get; set; } = new DateTime();

        public DateTime? EndDate { get; set; } = new DateTime();
        
    }
}