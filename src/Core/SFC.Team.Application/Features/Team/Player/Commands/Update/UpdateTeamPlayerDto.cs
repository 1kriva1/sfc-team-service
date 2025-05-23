using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Common.Dto;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Commands.Update;
public class UpdateTeamPlayerDto : BaseTeamPlayerDto, IMapTo<TeamPlayer>
{
    public int Status { get; set; }

    public string TeamComment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateTeamPlayerDto, TeamPlayer>()
                                                   .ForMember(p => p.StatusId, d => d.MapFrom(z => z.Status));
}