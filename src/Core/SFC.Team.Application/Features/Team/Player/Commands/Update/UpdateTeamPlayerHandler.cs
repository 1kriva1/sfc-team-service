using AutoMapper;

using MediatR;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Exceptions;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Domain.Events.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Commands.Update;
public class UpdateTeamPlayerHandler(IMapper mapper, ITeamPlayerRepository teamPlayerRepository)
    : IRequestHandler<UpdateTeamPlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRepository _teamPlayerRepository = teamPlayerRepository;

    public async Task Handle(UpdateTeamPlayerCommand request, CancellationToken cancellationToken)
    {
        TeamPlayer teamPlayer = await _teamPlayerRepository
            .GetByIdAsync(request.TeamPlayer.TeamId, request.TeamPlayer.PlayerId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.TeamPlayerNotFound);

        TeamPlayer updatedTeamPlayer = _mapper.Map(request.TeamPlayer, teamPlayer);

        updatedTeamPlayer.AddDomainEvent(new TeamPlayerUpdatedEvent(updatedTeamPlayer));

        await _teamPlayerRepository.UpdateAsync(updatedTeamPlayer)
                                   .ConfigureAwait(false);
    }
}