using ExempleSupportPortail.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExempleSupportPortail.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class MeController : ControllerBase
    {
        /// <summary>
        /// Get the current user issues
        /// </summary>
        /// <remarks>Get the user issue list with no paging feature.</remarks>
        /// <returns>A list of issues</returns>
        [HttpGet("issues", Name = nameof(GetUserIssues))]
        [ProducesResponseType(typeof(IEnumerable<IssueDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IEnumerable<IssueDto> GetUserIssues([FromServices] SupportContext sc)
            => sc.Issues
                .Include(issue => issue.User)
                .Include(issue => issue.Area)
                .Include(issue => issue.Status)
                .Select(issue => new IssueDto(issue));
    }
}
