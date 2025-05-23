using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Common.Dto;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerViewModel : IMapFrom<TeamPlayer>
{
    public required TeamPlayerDto TeamPlayer { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<TeamPlayer, CreateTeamPlayerViewModel>()
                                                   .ForMember(p => p.TeamPlayer, d => d.MapFrom(z => z));
}