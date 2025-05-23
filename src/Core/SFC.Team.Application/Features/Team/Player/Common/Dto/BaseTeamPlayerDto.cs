namespace SFC.Team.Application.Features.Team.Player.Common.Dto;
public class BaseTeamPlayerDto
{
    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public Guid UserId { get; set; }
}