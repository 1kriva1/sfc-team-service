using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Team.Api.Infrastructure.Extensions;
using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Pagination;
using SFC.Team.Api.Infrastructure.Models.Teams.General.Create;
using SFC.Team.Api.Infrastructure.Models.Teams.General.Find;
using SFC.Team.Api.Infrastructure.Models.Teams.General.Get;
using SFC.Team.Api.Infrastructure.Models.Teams.General.Update;
using SFC.Team.Application.Features.Common.Base;
using SFC.Team.Application.Features.Team.General.Commands.Create;
using SFC.Team.Application.Features.Team.General.Commands.Update;
using SFC.Team.Application.Features.Team.General.Queries.Find;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;
using SFC.Team.Application.Features.Team.General.Queries.Get;
using SFC.Team.Infrastructure.Constants;

namespace SFC.Team.Api.Controllers;

/// <summary>
/// Team general controller:
/// - create team
/// - update team
/// - get/find teams
/// </summary>
[Tags("Team")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class TeamsController : ApiControllerBase
{
    /// <summary>
    /// Create new team.
    /// </summary>
    /// <param name="request">Create team request.</param>
    /// <returns>An ActionResult of type CreateTeamResponse</returns>
    /// <response code="201">Returns **new** created team.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpPost]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CreateTeamResponse>> CreateTeamAsync([FromBody] CreateTeamRequest request)
    {
        CreateTeamCommand command = Mapper.Map<CreateTeamCommand>(request);

        CreateTeamViewModel model = await Mediator.Send(command)
                                                  .ConfigureAwait(false);

        return CreatedAtRoute("GetTeam", new { id = model.Team.Id }, Mapper.Map<CreateTeamResponse>(model));
    }

    /// <summary>
    /// Update existing team.
    /// </summary>
    /// <param name="id">Team unique identifier.</param>
    /// <param name="request">Update team request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if team updated **successfully**.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpPut("{id}")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> UpdateTeamAsync([FromRoute] long id, [FromBody] UpdateTeamRequest request)
    {
        UpdateTeamCommand command = Mapper.Map<UpdateTeamCommand>(request)
                                          .SetTeamId(id);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return team model by unique identifier.
    /// </summary>
    /// <param name="id">Team unique identifier.</param>
    /// <returns>An ActionResult of type GetTeamResponse</returns>
    /// <response code="200">Returns team model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when team **not found** by unique identifier.</response>
    [HttpGet("{id}", Name = "GetTeam")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetTeamResponse>> GetTeamAsync([FromRoute] long id)
    {
        GetTeamQuery query = new() { TeamId = id };

        GetTeamViewModel team = await Mediator.Send(query)
                                              .ConfigureAwait(false);

        return Ok(Mapper.Map<GetTeamResponse>(team));
    }

    /// <summary>
    /// Return list of teams
    /// </summary>
    /// <param name="request">Get teams request.</param>
    /// <returns>An ActionResult of type GetTeamsResponse</returns>
    /// <response code="200">Returns list of teams with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetTeamsResponse>> GetTeamsAsync([FromQuery] GetTeamsRequest request)
    {
        BasePaginationRequest<GetTeamsViewModel, GetTeamsFilterDto> query = Mapper.Map<GetTeamsQuery>(request);

        GetTeamsViewModel result = await Mediator.Send(query)
                                                 .ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetTeamsResponse>(result));
    }
}