using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Common.Dto;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Common;

/// <summary>
/// Team model.
/// </summary>
public class TeamModel : BaseTeamModel, IMapFrom<TeamDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }
}