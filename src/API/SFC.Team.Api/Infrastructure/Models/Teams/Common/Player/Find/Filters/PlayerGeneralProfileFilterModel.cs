using SFC.Team.Api.Infrastructure.Models.Common;
using SFC.Team.Application.Common.Dto.Player.Filters;
using SFC.Team.Application.Common.Mappings.Interfaces;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Common.Player.Find.Filters;

/// <summary>
/// Get players **general profile filter** model.
/// </summary>
public class PlayerGeneralProfileFilterModel : IMapTo<PlayerGeneralProfileFilterDto>
{
    /// <summary>
    /// Name (first and last).
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// **City** where player will play football.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Player's **tags**.
    /// </summary>
    public IEnumerable<string> Tags { get; set; } = default!;

    /// <summary>
    /// Range limit for players age.
    /// </summary>
    public RangeLimitModel<short?> Years { get; set; } = default!;

    /// <summary>
    /// Player's **availability** model.
    /// </summary>
    public PlayerAvailabilityLimitFilterModel Availability { get; set; } = default!;

    /// <summary>
    /// Describe if player can **pay** for football matches.
    /// </summary>
    public bool? FreePlay { get; set; }

    /// <summary>
    /// Describe if player must have uploaded photo.
    /// </summary>
    public bool? HasPhoto { get; set; }
}