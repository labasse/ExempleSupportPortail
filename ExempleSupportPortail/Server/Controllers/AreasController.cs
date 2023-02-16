using ExempleSupportPortail.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ExempleSupportPortail.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        /// <summary>
        /// Get the areas list.
        /// </summary>
        /// <remarks>Get the complete area list with no paging feature and no filter.</remarks>
        /// <returns>A list of areas.</returns>
        /// <response code="200">Areas successfully returned.</response>
        [HttpGet(Name = nameof(GetAllAreas))]
        [ProducesResponseType(typeof(IEnumerable<Area>), StatusCodes.Status200OK)]
        public IEnumerable<Area> GetAllAreas([FromServices] SupportContext sc)
            => sc.Areas;        
    }
}
