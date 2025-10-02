using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Common.Dto;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.General.Common.Dto;
public class TeamDto : BaseTeamDto, IMapFrom<TeamEntity>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public int StatusId { get; set; }

    public IEnumerable<TeamPlayerDto> Players { get; set; } = [];

    public new void Mapping(Profile profile) => profile.CreateMap<TeamEntity, TeamDto>()
                                                       .ForMember(p => p.Profile, d => d.MapFrom(z => z));
}