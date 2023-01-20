using System.ComponentModel.DataAnnotations;

namespace ExempleSupportPortail.Shared
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required, StringLength(50)]
        public required string Name { get; set; }

        [Required, StringLength(50)]
        public required string Login { get; set; }

        #region Populated by EF core
        public virtual ICollection<Issue> Requests { get; set; } = new List<Issue>();
        #endregion
    }
}
