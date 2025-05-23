using AutoMapper;

using MediatR;

using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Team.Domain.Events.Team.General;

namespace SFC.Team.Application.Features.Team.General.Commands.Create;
public class CreateTeamCommandHandler(IMapper mapper, ITeamRepository teamRepository)
    : IRequestHandler<CreateTeamCommand, CreateTeamViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamRepository _teamRepository = teamRepository;


    public async Task<CreateTeamViewModel> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        TeamEntity team = _mapper.Map<TeamEntity>(request.Team);

        team.AddDomainEvent(new TeamCreatedEvent(team));

        await _teamRepository.AddAsync(team)
                             .ConfigureAwait(false);

        return _mapper.Map<CreateTeamViewModel>(team);
    }
}