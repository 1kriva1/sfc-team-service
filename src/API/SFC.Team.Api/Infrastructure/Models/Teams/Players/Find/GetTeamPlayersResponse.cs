using AutoMapper;

using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Teams.Players.Common;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Queries.Find;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Players.Find;

/// <summary>
/// **Get** team players response.
/// </summary>
public class GetTeamPlayersResponse : BaseListResponse<TeamPlayerModel>, IMapFrom<GetTeamPlayersViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetTeamPlayersViewModel, GetTeamPlayersResponse>()
                                                   .IgnoreAllNonExisting();
}