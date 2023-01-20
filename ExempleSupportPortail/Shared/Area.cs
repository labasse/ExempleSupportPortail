using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExempleSupportPortail.Shared
{
    public class Area
    {
        [Key, JsonIgnore]
        public int IdArea { get; set; }
        
        [Required, StringLength(50)]
        public required string Title { get; set; }
    }
}
