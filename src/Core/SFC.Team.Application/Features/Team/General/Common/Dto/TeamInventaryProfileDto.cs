using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;

namespace SFC.Team.Application.Features.Team.General.Common.Dto;
public class TeamInventaryProfileDto : IMapFrom<TeamEntity>
{
    public IEnumerable<int> Shirts { get; set; } = [];

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamEntity, TeamInventaryProfileDto>()
               .ForMember(p => p.Shirts, d => d.MapFrom(z => z.Shirts));
    }
}