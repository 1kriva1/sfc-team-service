using AutoMapper;

using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Application.Features.Team.General.Common.Dto;
public class TeamInventaryProfileDto : IMapFrom<TeamEntity>, IMapTo<TeamInventaryProfile>
{
    public IEnumerable<int> Shirts { get; set; } = [];

    public bool HasManiches { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamEntity, TeamInventaryProfileDto>()
               .ForMember(p => p.HasManiches, d => d.MapFrom(z => z.InventaryProfile.HasManiches))
               .ReverseMap();

        profile.CreateMap<TeamInventaryProfileDto, TeamInventaryProfile>()
               .IgnoreAllNonExisting();
    }
}