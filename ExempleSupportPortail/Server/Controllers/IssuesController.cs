using ExempleSupportPortail.Server.Services;
using ExempleSupportPortail.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExempleSupportPortail.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private ApiKeyManager apiKeyManager;
        private SupportContext db;

        public IssuesController(ApiKeyManager apiKeyManager, SupportContext db)
        {
            this.apiKeyManager = apiKeyManager;
            this.db = db;
        }
        /// <summary>
        /// Get all the issues
        /// </summary>
        /// <remarks>Get the complete issue list with no paging feature and no user filter.</remarks>
        /// <returns>A list of issues</returns>
        /// <response code="200">Issue list successfully found</response>
        /// <response code="400">Bad parameters</response>
        /// <response code="401">Incorrect API key provided</response>
        [HttpGet(Name = nameof(GetAllIssues))]
        [ProducesResponseType(typeof(IEnumerable<IssueDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IEnumerable<IssueDto>> GetAllIssues([FromHeader(Name = "X-API-Key")] Guid apiKey) =>
            apiKeyManager.IsAuthorized(apiKey)
            ? Ok(db.Issues
                .Include(issue => issue.User)
                .Include(issue => issue.Status)
                .Include(issue => issue.Area)
                .Select(issue => new IssueDto(issue)))
            : Unauthorized("Bad API Key");

        /// <summary>
        /// Partially update an issue
        /// </summary>
        /// <remarks>Partially update an issue. Only status, comment and/or DateClosed can be updated.</remarks>
        /// <param name="apiKey">API Key</param>
        /// <param name="id">Id of issue to be updated</param>
        /// <param name="issueDto">Issue data to be updated</param>
        /// <response code="201">Issue successfully updated</response>
        /// <response code="400">Bad parameters</response>
        /// <response code="401">Incorrect API key provided</response>
        /// <response code="404">No issue found with this id</response>
        [HttpPatch("{id}", Name = nameof(UpdateIssue))]
        [ProducesResponseType(typeof(IssueDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IssueDto> UpdateIssue([FromHeader(Name = "X-API-Key")] Guid apiKey, int id, [FromBody] IssueDto issueDto)
        {
            if (!apiKeyManager.IsAuthorized(apiKey))
                return Unauthorized("Bad API key provided");

            var issue = db.Issues
                .Include(issue => issue.User)
                .Include(issue => issue.Area)
                .FirstOrDefault(x => x.IdIssue == id);

            if (issue is null)
                return NotFound("No issue found with this id");
            else if (issueDto.IdIssue is not null && issueDto.IdIssue != id)
                return BadRequest("Issue id mismatch");

            var status = db.Statuses.FirstOrDefault(x => x.Title == issueDto.Status);

            if (status is null)
                return BadRequest("Unknown status");
            else if (!issue.ChangeStatus(status.IdStatus, issueDto.DateClosed, issueDto.Comment))
                return BadRequest("Invalid status change");

            issue.Status = status;
            db.SaveChanges();
            return Ok(new IssueDto(issue));
        }
    }
}
