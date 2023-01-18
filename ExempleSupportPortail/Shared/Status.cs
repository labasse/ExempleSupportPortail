using System.Text.Json.Serialization;

namespace ExempleSupportPortail.Shared
{
    public class Status
    {
        [JsonIgnore]
        public int IdStatus { get; set; }

        public required string Title { get; set; }
    }
}
