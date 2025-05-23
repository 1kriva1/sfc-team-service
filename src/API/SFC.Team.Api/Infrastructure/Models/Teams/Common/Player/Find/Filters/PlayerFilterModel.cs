﻿using SFC.Team.Application.Common.Dto.Player.Filters;
using SFC.Team.Application.Common.Mappings.Interfaces;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Common.Player.Find.Filters;

/// <summary>
/// Get players filter model.
/// </summary>
public class PlayerFilterModel : IMapTo<PlayerFilterDto>
{
    /// <summary>
    /// Profile filter model.
    /// </summary>
    public PlayerProfileFilterModel Profile { get; set; } = default!;

    /// <summary>
    /// Stats filter model.
    /// </summary>
    public PlayerStatsFilterModel Stats { get; set; } = default!;
}