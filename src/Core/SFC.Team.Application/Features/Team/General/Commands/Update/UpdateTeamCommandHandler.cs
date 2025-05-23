using AutoMapper;

using MediatR;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Exceptions;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Team.Domain.Events.Team.General;

namespace SFC.Team.Application.Features.Team.General.Commands.Update;
public class UpdateTeamCommandHandler(IMapper mapper, ITeamRepository teamRepository)
    : IRequestHandler<UpdateTeamCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamRepository _teamRepository = teamRepository;

    public async Task Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        TeamEntity team = await _teamRepository.GetByIdAsync(request.TeamId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.TeamNotFound);

        TeamEntity updatedTeam = _mapper.Map(request.Team, team);

        updatedTeam.AddDomainEvent(new TeamUpdatedEvent(updatedTeam));

        await _teamRepository.UpdateAsync(updatedTeam)
                             .ConfigureAwait(false);
    }
}