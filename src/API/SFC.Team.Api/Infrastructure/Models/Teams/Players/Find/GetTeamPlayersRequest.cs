using AutoMapper;

using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Teams.Players.Find.Filters;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Queries.Find;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Players.Find;

/// <summary>
/// **Get** team players request.
/// </summary>
public class GetTeamPlayersRequest : BasePaginationRequest<GetTeamPlayersFilterModel>, IMapTo<GetTeamPlayersQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetTeamPlayersRequest, GetTeamPlayersQuery>()
                                                   .IgnoreAllNonExisting();
}