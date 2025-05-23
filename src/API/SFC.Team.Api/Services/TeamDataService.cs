using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Team.Application.Features.Team.Data.Queries.GetAll;
using SFC.Team.Contracts.Messages.Team.Data.GetAll;
using SFC.Team.Infrastructure.Constants;

using static SFC.Team.Contracts.Services.TeamDataService;

namespace SFC.Team.Api.Services;

[Authorize(Policy.General)]
public class TeamDataService(IMapper mapper, ISender mediator) : TeamDataServiceBase
{
    public override async Task<GetAllTeamDataResponse> GetAll(GetAllTeamDataRequest request, ServerCallContext context)
    {
        GetAllTeamDataQuery query = new();

        GetAllTeamDataViewModel model = await mediator.Send(query).ConfigureAwait(true);

        return mapper.Map<GetAllTeamDataResponse>(model);
    }
}