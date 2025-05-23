using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Common.Dto;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Common;

/// <summary>
/// Team's **inventary** profile model.
/// </summary>
public class TeamInventaryProfileModel : IMapFromReverse<TeamInventaryProfileDto>
{
    /// <summary>
    /// In what shirts team can play (multiple value).
    /// </summary>
    public IEnumerable<int> Shirts { get; set; } = [];
}