using System.ComponentModel.DataAnnotations;

namespace Catalog2.Models
{
    public class TaskItem
    {
        public int Id {get; set;}
        public string Name {get; set;} = "";
        public int? Priority {get; set;}
        public string Description {get; set;} = "none";
        public TaskStage? Class {get; set;}//current stage of the tusk
        public int projectId {get; set;}//Id of the project the task is in
        public Project? InProject { get; set; }//project where the task is stored
        public string? CustomField {get; set;}//additional field if adding new field is needed
    }
}