using ExempleSupportPortail.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExempleSupportPortail.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<IssueDto> Get([FromServices] SupportContext sc)
            => sc.Issues.Select(issue => new IssueDto(issue));
    }
}
