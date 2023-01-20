using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExempleSupportPortail.Shared
{
    public class Status
    {
        [Key, JsonIgnore]
        public int IdStatus { get; set; }

        [Required, StringLength(50)]
        public required string Title { get; set; }
    }
}
