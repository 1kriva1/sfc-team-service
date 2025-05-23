using SFC.Team.Application.Common.Dto.Player.General;
using SFC.Team.Application.Common.Mappings.Interfaces;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Common.Player.Result;

/// <summary>
/// Player stats model.
/// </summary>
public class PlayerStatsModel : IMapFrom<PlayerStatsDto>
{
    /// <summary>
    /// Stats.
    /// </summary>
    public IEnumerable<PlayerStatValueModel> Values { get; set; } = [];
}