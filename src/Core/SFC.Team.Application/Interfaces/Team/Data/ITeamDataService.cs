using SFC.Team.Application.Interfaces.Team.Data.Models;

namespace SFC.Team.Application.Interfaces.Team.Data;
public interface ITeamDataService
{
    Task<GetAllTeamDataModel> GetAllTeamDataAsync();

    Task<GetInviteDataModel> GetInviteDataAsync();

    Task<GetRequestDataModel> GetRequestDataAsync();

    Task<GetSchemeDataModel> GetSchemeDataAsync();
}