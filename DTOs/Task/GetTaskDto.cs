namespace Catalog2.DTOs.Task
{
    public class GetTaskDto
    {
        public int Id {get; set;}
        public string Name {get; set;} = "";
        public int? Priority {get; set;}
        public string Description {get; set;} = "none";
        public TaskStage? Class {get; set;}
        public int projectId {get; set;}
    }
}