using ExempleSupportPortail.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ExempleSupportPortail.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Area> Get([FromServices] SupportContext sc)
            => sc.Areas;        
    }
}
