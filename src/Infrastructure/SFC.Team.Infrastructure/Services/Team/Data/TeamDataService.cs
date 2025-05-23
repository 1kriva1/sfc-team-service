using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Team.Application.Interfaces.Team.Data;
using SFC.Team.Application.Interfaces.Team.Data.Models;

namespace SFC.Team.Infrastructure.Services.Team.Data;
public class TeamDataService(ITeamPlayerStatusRepository teamPlayerStatusesRepository) : ITeamDataService
{
    private readonly ITeamPlayerStatusRepository _teamPlayerStatusesRepository = teamPlayerStatusesRepository;

    public async Task<GetAllTeamDataModel> GetAllTeamDataAsync()
    {
        return new()
        {
            TeamPlayerStatuses = await _teamPlayerStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task<GetInviteDataModel> GetInviteDataAsync()
    {
        return new()
        {
            TeamPlayerStatuses = await _teamPlayerStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task<GetRequestDataModel> GetRequestDataAsync()
    {
        return new()
        {
            TeamPlayerStatuses = await _teamPlayerStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task<GetSchemeDataModel> GetSchemeDataAsync()
    {
        return new()
        {
            TeamPlayerStatuses = await _teamPlayerStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }
}