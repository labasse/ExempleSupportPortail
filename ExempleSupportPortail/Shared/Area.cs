using System.Text.Json.Serialization;

namespace ExempleSupportPortail.Shared
{
    public class Area
    {
        [JsonIgnore]
        public int IdArea { get; set; }
        public required string Title { get; set; }
    }
}
