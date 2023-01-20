using System.ComponentModel.DataAnnotations;

namespace ExempleSupportPortail.Shared
{
    public class Issue
    {
        [Key]
        public int IdIssue { get; set; }

        public int UserId { get; set; }
        public int AreaId { get; set; }
        public int StatusId { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateClosed { get; set; }

        [Required, StringLength(50)]
        public required string Subject { get; set; }
        
        [Required, StringLength(255)]
        public required string Description { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }

        #region Populated by EF core
        #pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public virtual User User { get; set; }
        public virtual Area Area { get; set; }
        public virtual Status Status { get; set; }
        #pragma warning restore CS8618
        #endregion
    }
}
