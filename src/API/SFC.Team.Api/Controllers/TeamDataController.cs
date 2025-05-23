using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Teams.Data.GetAll;
using SFC.Team.Application.Features.Team.Data.Queries.GetAll;
using SFC.Team.Infrastructure.Constants;

namespace SFC.Team.Api.Controllers;

[Tags("Team Data")]
[Route("api/Teams/Data")]
[Authorize(Policy.General)]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
public class TeamDataController : ApiControllerBase
{
    /// <summary>
    /// Return all available team data types.
    /// </summary>
    /// <returns>An ActionResult of type GetAllTeamDataResponse</returns>
    /// <response code="200">Returns all available **data types**.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetAllTeamDataResponse>> GetAllAsync()
    {
        GetAllTeamDataQuery query = new();

        GetAllTeamDataViewModel model = await Mediator.Send(query).ConfigureAwait(true);

        return Ok(Mapper.Map<GetAllTeamDataResponse>(model));
    }
}