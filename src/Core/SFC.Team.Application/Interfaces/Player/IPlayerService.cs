using SFC.Team.Application.Common.Dto.Player.General;

namespace SFC.Team.Application.Interfaces.Player;
public interface IPlayerService
{
    Task<PlayerDto?> GetPlayerAsync(long id, CancellationToken cancellationToken = default);
}