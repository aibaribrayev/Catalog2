using System.Text.Json.Serialization;

namespace Catalog2.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProjectStatus
    {
        NotStarted = 1, 

        Active = 2, 

        Completed = 3

    }
}