using AutoMapper;

using MediatR;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Exceptions;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;

namespace SFC.Team.Application.Features.Team.General.Queries.Get;
public class GetTeamQueryHandler(IMapper mapper, ITeamRepository teamRepository)
    : IRequestHandler<GetTeamQuery, GetTeamViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamRepository _teamRepository = teamRepository;

    public async Task<GetTeamViewModel> Handle(GetTeamQuery request, CancellationToken cancellationToken)
    {
        TeamEntity team = await _teamRepository.GetByIdAsync(request.TeamId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.TeamNotFound);

        return _mapper.Map<GetTeamViewModel>(team);
    }
}