using SFC.Team.Application.Common.Dto.Player.General;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Common.Dto;
public class TeamPlayerDto : IMapFrom<TeamPlayer>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long TeamId { get; set; }

    public int StatusId { get; set; }

    public required PlayerDto Player { get; set; }
}