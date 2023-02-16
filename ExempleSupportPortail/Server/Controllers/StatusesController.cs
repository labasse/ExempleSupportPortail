using ExempleSupportPortail.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExempleSupportPortail.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        /// <summary>
        /// Get the issue status list.
        /// </summary>
        /// <remarks>Get the complete issue status list with no paging feature and no filter.</remarks>
        /// <returns>A list of statuses.</returns>
        /// <response code="200">Statuses successfully returned.</response>
        [HttpGet(Name = nameof(GetAllStatuses))]
        [ProducesResponseType(typeof(IEnumerable<Status>), StatusCodes.Status200OK)]
        public IEnumerable<Status> GetAllStatuses([FromServices] SupportContext sc)
            => sc.Statuses;
    }
}
