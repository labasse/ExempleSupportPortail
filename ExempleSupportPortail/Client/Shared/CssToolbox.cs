using ExempleSupportPortail.Shared;

namespace ExempleSupportPortail.Client.Shared
{
    public static class CssToolbox
    {
        public static string StatusCssClass(this IssueDto issue) =>
            issue.Status switch
            {
                "In progress" => "warning",
                "On hold" => "danger",
                "Closed" => "success",
                _ => "muted"
            };        
    }
}
