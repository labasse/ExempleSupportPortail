using ExempleSupportPortail.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExempleSupportPortail.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Status> Get([FromServices] SupportContext sc)
            => sc.Statuses;
    }
}
