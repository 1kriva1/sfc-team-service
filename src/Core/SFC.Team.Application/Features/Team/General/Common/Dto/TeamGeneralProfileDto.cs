using AutoMapper;

using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Application.Features.Team.General.Common.Dto;
public class TeamGeneralProfileDto : IMapFrom<TeamEntity>, IMapTo<TeamGeneralProfile>
{
    public required string Name { get; set; }

    public required string City { get; set; }

    public long? LocationId { get; set; }

    public string? Description { get; set; }

    public TeamLogoDto? Logo { get; set; }

    public IEnumerable<string> Tags { get; set; } = [];

    public IEnumerable<TeamAvailabilityDto> Availability { get; set; } = [];

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamEntity, TeamGeneralProfileDto>()
               .ForMember(p => p.Name, d => d.MapFrom(z => z.GeneralProfile.Name))
               .ForMember(p => p.City, d => d.MapFrom(z => z.GeneralProfile.City))
               .ForMember(p => p.LocationId, d => d.MapFrom(z => z.GeneralProfile.LocationId))
               .ForMember(p => p.Description, d => d.MapFrom(z => z.GeneralProfile.Description))
               .ReverseMap();

        profile.CreateMap<TeamGeneralProfileDto, TeamGeneralProfile>()
               .IgnoreAllNonExisting();
    }
}