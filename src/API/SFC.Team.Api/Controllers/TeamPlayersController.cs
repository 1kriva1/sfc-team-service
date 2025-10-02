using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Team.Api.Infrastructure.Extensions;
using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Pagination;
using SFC.Team.Api.Infrastructure.Models.Team.Player.Exist;
using SFC.Team.Api.Infrastructure.Models.Team.Player.Find;
using SFC.Team.Api.Infrastructure.Models.Team.Player.GetAll;
using SFC.Team.Api.Infrastructure.Models.Team.Player.Update.Remove;
using SFC.Team.Application.Features.Common.Base;
using SFC.Team.Application.Features.Team.Player.Commands.Update;
using SFC.Team.Application.Features.Team.Player.Queries.Exist;
using SFC.Team.Application.Features.Team.Player.Queries.Find;
using SFC.Team.Application.Features.Team.Player.Queries.Find.Dto.Filters;
using SFC.Team.Application.Features.Team.Player.Queries.GetAll;
using SFC.Team.Infrastructure.Constants;

namespace SFC.Team.Api.Controllers;

/// <summary>
/// Team players controller:
/// - remove player from team
/// - find team player
/// </summary>
[Tags("Team Players")]
[Route("api/Teams/{id}")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class TeamPlayersController : ApiControllerBase
{
    /// <summary>
    /// Check if Player exist in team
    /// </summary>
    /// <param name="id">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="status">Team player status Id.</param>
    /// <returns>An ActionResult of type TeamPlayerExistResponse</returns>
    /// <response code="200">Returns team player existence check result.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet("Players/{playerId}")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]

    public async Task<ActionResult<TeamPlayerExistResponse>> TeamPlayerExistAsync([FromRoute] long id, [FromRoute] long playerId, [FromQuery] int? status)
    {
        TeamPlayerExistQuery query = new() { TeamId = id, PlayerId = playerId, Status = (TeamPlayerStatusEnum?)status };

        TeamPlayerExistViewModel existence = await Mediator.Send(query)
                                                           .ConfigureAwait(false);

        return Ok(Mapper.Map<TeamPlayerExistResponse>(existence));
    }

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
    [HttpPut("Players/{playerId}/Remove")]
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
    /// Return team player models by team Id.
    /// </summary>
    /// <param name="id">Team unique identifier.</param>
    /// <returns>An ActionResult of type GetAllTeamPlayersResponse</returns>
    /// <response code="200">Returns team player models.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Players")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetAllTeamPlayersResponse>> GetTeamPlayersAsync([FromRoute] long id)
    {
        GetAllTeamPlayersQuery query = new() { TeamId = id };

        GetAllTeamPlayersViewModel teamPlayers = await Mediator.Send(query)
                                                               .ConfigureAwait(false);

        return Ok(Mapper.Map<GetAllTeamPlayersResponse>(teamPlayers));
    }

    /// <summary>
    /// Return list of team players.
    /// </summary>
    /// <param name="id">Team Id.</param>
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
    public async Task<ActionResult<GetTeamPlayersResponse>> GetTeamPlayersAsync([FromRoute] long id, [FromQuery] GetTeamPlayersRequest request)
    {
        BasePaginationRequest<GetTeamPlayersViewModel, GetTeamPlayersFilterDto> query = Mapper.Map<GetTeamPlayersQuery>(request)
                                                                                             .SetTeamId(id);

        GetTeamPlayersViewModel result = await Mediator.Send(query)
                                                       .ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetTeamPlayersResponse>(result));
    }
}