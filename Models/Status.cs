using System.Text.Json.Serialization;

namespace Catalog2.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        ToDo = 1, 

        InProgress = 2, 

        Done = 3
    }
}