using AutoMapper;

using MediatR;

using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Queries.GetAll;
public class GetAllTeamPlayersQueryHandler(IMapper mapper, ITeamPlayerRepository teamPlayerRepository)
    : IRequestHandler<GetAllTeamPlayersQuery, GetAllTeamPlayersViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRepository _teamPlayerRepository = teamPlayerRepository;

    public async Task<GetAllTeamPlayersViewModel> Handle(GetAllTeamPlayersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<TeamPlayer> teamPlayers = await _teamPlayerRepository
            .ListAllAsync(request.TeamId, TeamPlayerStatusEnum.Active).ConfigureAwait(true);

        return _mapper.Map<GetAllTeamPlayersViewModel>(teamPlayers);
    }
}