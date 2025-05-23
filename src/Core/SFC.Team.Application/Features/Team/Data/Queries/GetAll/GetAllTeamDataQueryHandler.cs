using AutoMapper;

using MediatR;

using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Features.Team.Data.Queries.Common.Dto;
using SFC.Team.Application.Interfaces.Team.Data;
using SFC.Team.Application.Interfaces.Team.Data.Models;

namespace SFC.Team.Application.Features.Team.Data.Queries.GetAll;

public class GetAllTeamDataQueryHandler(IMapper mapper, ITeamDataService teamDataService)
    : IRequestHandler<GetAllTeamDataQuery, GetAllTeamDataViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamDataService _teamDataService = teamDataService;

    public async Task<GetAllTeamDataViewModel> Handle(GetAllTeamDataQuery request, CancellationToken cancellationToken)
    {
        GetAllTeamDataModel model = await _teamDataService.GetAllTeamDataAsync().ConfigureAwait(true);

        return new GetAllTeamDataViewModel
        {
            TeamPlayerStatuses = _mapper.Map<IEnumerable<DataValueDto>>(model.TeamPlayerStatuses.Localize())
        };
    }
}