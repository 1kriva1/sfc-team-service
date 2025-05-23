using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Common.Dto;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerDto : BaseTeamPlayerDto, IMapTo<TeamPlayer> { }