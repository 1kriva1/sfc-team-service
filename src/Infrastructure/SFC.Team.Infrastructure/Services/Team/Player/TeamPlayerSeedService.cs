using AutoMapper;

using MassTransit;

using SFC.Team.Application.Interfaces.Common;
using SFC.Team.Application.Interfaces.Metadata;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Application.Interfaces.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Messages.Events.Team.Player;

namespace SFC.Team.Infrastructure.Services.Team.Player;
public class TeamPlayerSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    ITeamPlayerRepository teamPlayerRepository,
    ITeamRepository teamRepository) : ITeamPlayerSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly ITeamPlayerRepository _teamPlayerRepository = teamPlayerRepository;
    private readonly ITeamRepository _teamRepository = teamRepository;

    #region Stub data

    private static readonly IEnumerable<(TeamPlayerStatusEnum, long)> TEAM_PLAYER_IDS =
    [
        (TeamPlayerStatusEnum.Active, 1),
        (TeamPlayerStatusEnum.Removed, 2),
        (TeamPlayerStatusEnum.Removed, 3),
        (TeamPlayerStatusEnum.Removed, 4),
        (TeamPlayerStatusEnum.Active, 5),
        (TeamPlayerStatusEnum.Active, 6),
        (TeamPlayerStatusEnum.Active, 7),
        (TeamPlayerStatusEnum.Active, 8)
    ];
    private static readonly List<long> PLAYER_IDS = [20, 21, 22, 23, 24, 25];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<TeamPlayer>> GetSeedTeamPlayersAsync()
    {
        return await _teamPlayerRepository.GetByIdsAsync(TEAM_PLAYER_IDS.Select(item => item.Item2), PLAYER_IDS).ConfigureAwait(true);
    }

    public async Task SeedTeamPlayersAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<TeamPlayer> teamPlayers = await CreateSeedTeamPlayersAsync().ConfigureAwait(true);

        TeamPlayer[] seedTeamPlayers = await _teamPlayerRepository.AddRangeIfNotExistsAsync([.. teamPlayers]).ConfigureAwait(true);

        await PublishTeamPlayersSeededEventAsync(seedTeamPlayers, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Team, MetadataDomainEnum.TeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<TeamPlayer>> CreateSeedTeamPlayersAsync()
    {
        List<TeamPlayer> result = [];

        foreach ((TeamPlayerStatusEnum, long) item in TEAM_PLAYER_IDS)
        {
            IEnumerable<TeamPlayer> part = await BuildTeamPlayerAsync(item.Item2, item.Item1).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<TeamPlayer>> BuildTeamPlayerAsync(long teamId, TeamPlayerStatusEnum status)
    {
        TeamEntity? team = await _teamRepository.GetByIdAsync(teamId).ConfigureAwait(true);

        Guid userId = team!.UserId;

        DateTime createdDate = _dateTimeService.Now;

        return PLAYER_IDS.Select(playerId => new TeamPlayer()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
            UserId = userId,
            TeamId = teamId,
            PlayerId = playerId,
            StatusId = status
        });
    }

    private Task PublishTeamPlayersSeededEventAsync(IEnumerable<TeamPlayer> teamPlayers, CancellationToken cancellationToken = default)
    {
        TeamPlayersSeeded @event = _mapper.Map<TeamPlayersSeeded>(teamPlayers);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}