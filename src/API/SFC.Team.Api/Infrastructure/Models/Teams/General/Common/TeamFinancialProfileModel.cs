using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Common.Dto;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Common;

/// <summary>
/// Team's **financial** profile model.
/// </summary>
public class TeamFinancialProfileModel : IMapFromReverse<TeamFinancialProfileDto>
{
    /// <summary>
    /// Team play only on free field and without any extra expansions.
    /// </summary>
    public bool? FreePlay { get; set; }
}