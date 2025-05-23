﻿using AutoMapper;

using Microsoft.Extensions.Configuration;

using SFC.Player.Contracts.Messages.Player.General.Get;
using SFC.Team.Application.Common.Dto.Player.General;
using SFC.Team.Application.Interfaces.Player;
using SFC.Team.Infrastructure.Extensions.Grpc;

using static SFC.Player.Contracts.Services.PlayerService;

namespace SFC.Team.Infrastructure.Services.Player;
public class PlayerService(
    PlayerServiceClient client,
    IMapper mapper,
    IConfiguration configuration) : IPlayerService
{
    private readonly PlayerServiceClient _client = client;
    private readonly IMapper _mapper = mapper;
    private readonly IConfiguration _configuration = configuration;

    public async Task<PlayerDto?> GetPlayerAsync(long id, CancellationToken cancellationToken = default)
    {
        GetPlayerRequest request = _mapper.Map<GetPlayerRequest>(id);

        return await GrpcClientExtensions.CallWithAuditableAsync(
            (Func<GetPlayerRequest, Grpc.Core.Metadata, DateTime?, CancellationToken, Grpc.Core.AsyncUnaryCall<GetPlayerResponse>>)_client.GetPlayerAsync,
            (GetPlayerRequest)request,
            _configuration,
            (response) => _mapper.Map<PlayerDto>(response.Player),
            null,
            cancellationToken).ConfigureAwait(true);
    }
}