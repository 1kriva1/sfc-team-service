using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Queries.Exist;
using SFC.Team.Application.Features.Team.Player.Queries.GetAll;

namespace SFC.Team.Api.Infrastructure.Models.Team.Player.Exist;

/// <summary>
/// Described the result of check if player **exist** in team.
/// </summary>
public class TeamPlayerExistResponse : BaseResponse, IMapFrom<TeamPlayerExistViewModel>
{
    /// <summary>
    /// Determined if Player in Team.
    /// </summary>
    public bool Exist { get; set; }
}