using AutoMapper;

using MediatR;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Exceptions;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Queries.Get;
public class GetTeamPlayerQueryHandler(IMapper mapper, ITeamPlayerRepository teamPlayerRepository)
    : IRequestHandler<GetTeamPlayerQuery, GetTeamPlayerViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRepository _teamPlayerRepository = teamPlayerRepository;

    public async Task<GetTeamPlayerViewModel> Handle(GetTeamPlayerQuery request, CancellationToken cancellationToken)
    {
        TeamPlayer team = await _teamPlayerRepository.GetByIdAsync(request.Id, request.TeamId, request.PlayerId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.TeamPlayerNotFound);

        return _mapper.Map<GetTeamPlayerViewModel>(team);
    }
}