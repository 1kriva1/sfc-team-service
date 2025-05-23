using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Common.Dto;

namespace SFC.Team.Application.Features.Team.General.Queries.Get;
public class GetTeamViewModel : IMapFrom<TeamEntity>
{
    public required TeamDto Team { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<TeamEntity, GetTeamViewModel>()
                                                   .ForMember(p => p.Team, d => d.MapFrom(z => z));
}