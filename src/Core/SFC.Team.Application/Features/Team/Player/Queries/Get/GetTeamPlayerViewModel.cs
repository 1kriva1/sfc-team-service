using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Common.Dto;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Queries.Get;
public class GetTeamPlayerViewModel : IMapFrom<TeamPlayer>
{
    public required TeamPlayerDto TeamPlayer { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<TeamPlayer, GetTeamPlayerViewModel>()
                                                   .ForMember(p => p.TeamPlayer, d => d.MapFrom(z => z));
}