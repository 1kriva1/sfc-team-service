using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Common.Dto;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Queries.GetAll;
public class GetAllTeamPlayersViewModel : IMapFrom<IEnumerable<TeamPlayer>>
{
    public required IEnumerable<TeamPlayerDto> TeamPlayers { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<IEnumerable<TeamPlayer>, GetAllTeamPlayersViewModel>()
                                                   .ForMember(p => p.TeamPlayers, d => d.MapFrom(z => z));
}