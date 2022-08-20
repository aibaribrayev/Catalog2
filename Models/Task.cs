namespace Catalog2.Models
{
    public class TaskItem
    {
        public int Id {get; set;}
        public string Name {get; set;} = "";
        public int Priority {get; set;}
        public string Description {get; set;} = "none";
        public Status Class {get; set;} = Status.ToDo;
    }
}