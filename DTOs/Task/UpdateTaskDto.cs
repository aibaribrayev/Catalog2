namespace Catalog2.DTOs.Task
{
    public class UpdateTaskDto
    {
        public int Id {get; set;}
        public string Name {get; set;} = "";
        public int? Priority {get; set;}
        public string Description {get; set;} = "none";
        public TaskStage? Class {get; set;} = TaskStage.ToDo;
        public int projectId {get; set;}
    }
}