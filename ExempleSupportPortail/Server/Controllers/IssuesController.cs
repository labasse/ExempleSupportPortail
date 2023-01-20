using ExempleSupportPortail.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExempleSupportPortail.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<IssueDto> Get([FromServices] SupportContext sc)
            => sc.Issues
                .Include(issue => issue.User)
                .Include(issue => issue.Area)
                .Include(issue => issue.Status)
                .Select(issue => new IssueDto(issue));
    }
}
