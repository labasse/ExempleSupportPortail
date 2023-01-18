namespace ExempleSupportPortail.Shared
{
    public class Issue
    {
        public int IdIssue { get; set; }
        public required User User { get; init; }
        public required Area Area { get; init; }
        public required Status Status { get; set; }
        public DateTime DateCreated { get; init; } = DateTime.Now;
        public DateTime? DateClosed { get; set; }
        public required string Subject { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }
    }
}
