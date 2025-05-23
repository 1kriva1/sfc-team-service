using AutoMapper;

using MediatR;

using SFC.Team.Application.Features.Team.Player.Common.Extensions;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Domain.Events.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerHandler(
    IMapper mapper,
    ITeamPlayerRepository teamPlayerRepository)
    : IRequestHandler<CreateTeamPlayerCommand, CreateTeamPlayerViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRepository _teamPlayerRepository = teamPlayerRepository;

    public async Task<CreateTeamPlayerViewModel> Handle(CreateTeamPlayerCommand request, CancellationToken cancellationToken)
    {
        TeamPlayer teamPlayer = _mapper.Map<TeamPlayer>(request.TeamPlayer)
                                       .SetStatus(TeamPlayerStatusEnum.Active);

        teamPlayer.AddDomainEvent(new TeamPlayerCreatedEvent(teamPlayer));

        await _teamPlayerRepository.AddAsync(teamPlayer)
                                   .ConfigureAwait(true);

        return _mapper.Map<CreateTeamPlayerViewModel>(teamPlayer);
    }
}