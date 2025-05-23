using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Find;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Find.Filters;

/// <summary>
/// Get teams **general profile filter** model.
/// </summary>
public class GetTeamsGeneralProfileFilterModel : IMapTo<GetTeamsGeneralProfileFilterDto>
{
    /// <summary>
    /// Name of team.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// **City** where team will play football.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Team's **tags**.
    /// </summary>
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// Team's **availability** model.
    /// </summary>
    public GetTeamsAvailabilityLimitModel? Availability { get; set; }

    /// <summary>
    /// **Location** where team mostly will play football.
    /// </summary>
    public long? Location { get; set; }

    /// <summary>
    /// Describe if team must have uploaded logo.
    /// </summary>
    public bool? HasLogo { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GetTeamsGeneralProfileFilterModel, GetTeamsGeneralProfileFilterDto>()
                                                   .ForMember(p => p.LocationId, d => d.MapFrom(z => z.Location));
}