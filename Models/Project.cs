namespace Catalog2.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = "project_name"; 
        public int Priority  {get; set;} 
        public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;
        public List<TaskItem>? Tasks { get; set; }
    }

}