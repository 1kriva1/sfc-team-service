﻿using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Common.Dto;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Common;

/// <summary>
/// Team's **general** profile model.
/// </summary>
public class TeamGeneralProfileModel : IMapFromReverse<TeamGeneralProfileDto>
{
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// **City** where team will play football.
    /// </summary>
    public required string City { get; set; }

    /// <summary>
    /// Location of main team field.
    /// </summary>
    public long? Location { get; set; }

    /// <summary>
    /// A few words about team.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Logo/Photo/Avatar.
    /// </summary>
    public string? Logo { get; set; }

    /// <summary>
    /// Team's **tags**.
    /// </summary>
    public IEnumerable<string> Tags { get; set; } = [];

    /// <summary>
    /// Team's **availabilities** to play (at what day and time can play).
    /// </summary>
    public IEnumerable<TeamAvailabilityModel> Availability { get; set; } = [];

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamGeneralProfileDto, TeamGeneralProfileModel>()
               .ForMember(p => p.Location, d => d.MapFrom(z => z.LocationId))
               .ReverseMap();
    }
}