using AutoMapper;

using MediatR;

using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Queries.Exist;
public class TeamPlayerExistQueryHandler(IMapper mapper, ITeamPlayerRepository teamPlayerRepository)
    : IRequestHandler<TeamPlayerExistQuery, TeamPlayerExistViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRepository _teamPlayerRepository = teamPlayerRepository;

    public async Task<TeamPlayerExistViewModel> Handle(TeamPlayerExistQuery request, CancellationToken cancellationToken)
    {
        bool exist = await _teamPlayerRepository.AnyAsync(request.TeamId, request.PlayerId, request.Status).ConfigureAwait(true);
        return _mapper.Map<TeamPlayerExistViewModel>(exist);
    }
}