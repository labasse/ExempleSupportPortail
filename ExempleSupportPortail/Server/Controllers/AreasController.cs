using ExempleSupportPortail.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ExempleSupportPortail.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        /// <summary>
        /// Get all areas
        /// </summary>
        /// <returns>List of areas with title.</returns>
        [HttpGet]
        public IEnumerable<Area> Get([FromServices] SupportContext sc)
            => sc.Areas;        
    }
}
