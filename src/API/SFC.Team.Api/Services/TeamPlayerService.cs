using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Team.Api.Infrastructure.Extensions;
using SFC.Team.Application.Features.Team.Player.Queries.Find;
using SFC.Team.Application.Features.Team.Player.Queries.Get;
using SFC.Team.Contracts.Headers;
using SFC.Team.Contracts.Messages.Team.Player.Find;
using SFC.Team.Contracts.Messages.Team.Player.Get;
using SFC.Team.Infrastructure.Constants;

using static SFC.Team.Contracts.Services.TeamPlayerService;

namespace SFC.Team.Api.Services;

[Authorize(Policy.General)]
public class TeamPlayerService(IMapper mapper, ISender mediator) : TeamPlayerServiceBase
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    public override async Task<GetTeamPlayerResponse> GetTeamPlayer(GetTeamPlayerRequest request, ServerCallContext context)
    {
        GetTeamPlayerQuery query = _mapper.Map<GetTeamPlayerQuery>(request);

        GetTeamPlayerViewModel model = await _mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(_mapper.Map<AuditableHeader>(model.TeamPlayer));

        return _mapper.Map<GetTeamPlayerResponse>(model);
    }

    public override async Task<GetTeamPlayersResponse> GetTeamPlayers(GetTeamPlayersRequest request, ServerCallContext context)
    {
        GetTeamPlayersQuery query = _mapper.Map<GetTeamPlayersQuery>(request);

        GetTeamPlayersViewModel result = await _mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(_mapper.Map<PaginationHeader>(result.Metadata));

        return _mapper.Map<GetTeamPlayersResponse>(result);
    }
}