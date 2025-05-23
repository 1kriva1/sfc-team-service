using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Common.Dto;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Common;

/// <summary>
/// Team **profile** model.
/// </summary>
public class TeamProfileModel : IMapFromReverse<TeamProfileDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public required TeamGeneralProfileModel General { get; set; }

    /// <summary>
    /// Financial profile.
    /// </summary>
    public required TeamFinancialProfileModel Financial { get; set; }

    /// <summary>
    /// Inventary profile.
    /// </summary>
    public required TeamInventaryProfileModel Inventary { get; set; }
}