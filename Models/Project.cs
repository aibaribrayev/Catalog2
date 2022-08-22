namespace Catalog2.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = "project_name"; 
        public int? Priority  {get; set;} 
        public ProjectStatus? Status { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<TaskItem>? Tasks { get; set; }// one to many connection [project : tasks]
    }

}