using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Team.Api.Infrastructure.Extensions;
using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Pagination;
using SFC.Team.Api.Infrastructure.Models.Teams.Players.Find;
using SFC.Team.Api.Infrastructure.Models.Teams.Players.Update.Remove;
using SFC.Team.Application.Features.Common.Base;
using SFC.Team.Application.Features.Team.Player.Commands.Update;
using SFC.Team.Application.Features.Team.Player.Queries.Find;
using SFC.Team.Application.Features.Team.Player.Queries.Find.Dto.Filters;
using SFC.Team.Infrastructure.Constants;

namespace SFC.Team.Api.Controllers;

/// <summary>
/// Team players controller:
/// - remove player from team
/// - find team player
/// </summary>
[Tags("Team Players")]
[Route("api/Teams")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class TeamPlayersController : ApiControllerBase
{
    /// <summary>
    /// Remove player from team.
    /// </summary>
    /// <param name="id">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="request">Remove player from team request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if player **successfully** removed from team.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{id}/Players/{playerId}/Remove")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> RemoveTeamPlayerAsync(
        [FromRoute] long id, [FromRoute] long playerId, [FromBody] RemoveTeamPlayerRequest request)
    {
        UpdateTeamPlayerCommand command = Mapper.Map<UpdateTeamPlayerCommand>(request)
                                                      .SetTeamId(id)
                                                      .SetPlayerId(playerId)
                                                      .SetStatus(TeamPlayerStatusEnum.Removed);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return list of team players.
    /// </summary>
    /// <param name="request">Get team players request.</param>
    /// <returns>An ActionResult of type GetTeamPlayersResponse</returns>
    /// <response code="200">Returns list of team players with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Players/Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetTeamPlayersResponse>> GetTeamPlayersAsync([FromQuery] GetTeamPlayersRequest request)
    {
        BasePaginationRequest<GetTeamPlayersViewModel, GetTeamPlayersFilterDto> query = Mapper.Map<GetTeamPlayersQuery>(request);

        GetTeamPlayersViewModel result = await Mediator.Send(query)
                                                       .ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetTeamPlayersResponse>(result));
    }
}