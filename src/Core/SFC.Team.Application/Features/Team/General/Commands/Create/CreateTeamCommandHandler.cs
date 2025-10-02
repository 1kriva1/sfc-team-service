using AutoMapper;

using MediatR;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Exceptions;
using SFC.Team.Application.Features.Team.General.Common.Extensions;
using SFC.Team.Application.Interfaces.Identity;
using SFC.Team.Application.Interfaces.Persistence.Repository.Player.General;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Domain.Events.Team.General;

namespace SFC.Team.Application.Features.Team.General.Commands.Create;
public class CreateTeamCommandHandler(
    IMapper mapper,
    ITeamRepository teamRepository,
    IPlayerRepository playerRepository,
    IUserService userService)
    : IRequestHandler<CreateTeamCommand, CreateTeamViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamRepository _teamRepository = teamRepository;
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private readonly IUserService _userService = userService;

    public async Task<CreateTeamViewModel> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        PlayerEntity userPlayer = await BuildUserTeamPlayerAsync().ConfigureAwait(true);

        TeamEntity team = _mapper.Map<TeamEntity>(request.Team)
                                 .SetStatus(TeamStatusEnum.Active)
                                 .AddUserPlayer(userPlayer);

        team.AddDomainEvent(new TeamCreatedEvent(team));

        await _teamRepository.AddAsync(team)
                             .ConfigureAwait(false);

        return _mapper.Map<CreateTeamViewModel>(team);
    }

    private async Task<PlayerEntity> BuildUserTeamPlayerAsync()
    {
        Guid userId = _userService.GetUserId()
            ?? throw new AuthorizationException(Localization.AuthorizationError);

        PlayerEntity? player = await _playerRepository.GetByUserIdAsync(userId).ConfigureAwait(true)
             ?? throw new AuthorizationException(Localization.PlayerNotFound);

        return player;
    }
}