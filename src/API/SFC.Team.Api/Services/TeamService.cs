using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Team.Api.Infrastructure.Extensions;
using SFC.Team.Application.Features.Team.General.Queries.Find;
using SFC.Team.Application.Features.Team.General.Queries.Get;
using SFC.Team.Contracts.Headers;
using SFC.Team.Contracts.Messages.Team.General.Find;
using SFC.Team.Contracts.Messages.Team.General.Get;
using SFC.Team.Infrastructure.Constants;

using static SFC.Team.Contracts.Services.TeamService;

namespace SFC.Team.Api.Services;

[Authorize(Policy.General)]
public class TeamService(IMapper mapper, ISender mediator) : TeamServiceBase
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    public override async Task<GetTeamResponse> GetTeam(GetTeamRequest request, ServerCallContext context)
    {
        GetTeamQuery query = _mapper.Map<GetTeamQuery>(request);

        GetTeamViewModel model = await _mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(_mapper.Map<AuditableHeader>(model.Team));

        return _mapper.Map<GetTeamResponse>(model);
    }

    public override async Task<GetTeamsResponse> GetTeams(GetTeamsRequest request, ServerCallContext context)
    {
        GetTeamsQuery query = _mapper.Map<GetTeamsQuery>(request);

        GetTeamsViewModel result = await _mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(_mapper.Map<PaginationHeader>(result.Metadata));

        return _mapper.Map<GetTeamsResponse>(result);
    }
}