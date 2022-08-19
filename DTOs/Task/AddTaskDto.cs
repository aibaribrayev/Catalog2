namespace Catalog2.DTOs.Task
{
    public class AddTaskDto
    {
        public string Name {get; set;} = "";
        public int Priority {get; set;}
        public string Description {get; set;} = "none";
        public Status Class {get; set;} = Status.ToDo;
    }
}