namespace ExempleSupportPortail.Shared
{
    public record IssueDto(int IdIssue, string User, string Area, string Status, DateTime DateCreated, DateTime? DateClosed, string Subject, string? Description, string? Comment)
    {
        public IssueDto(Issue issue) : this(issue.IdIssue, issue.User.Name, issue.Area.Title, issue.Status.Title, issue.DateCreated, issue.DateClosed, issue.Subject, issue.Description, issue.Comment)
        {
        }
    }
}
