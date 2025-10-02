using AutoMapper;

using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Team.General.Common;
using SFC.Team.Api.Infrastructure.Models.Team.General.Get;
using SFC.Team.Api.Infrastructure.Models.Team.Player.Common;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Get;
using SFC.Team.Application.Features.Team.Player.Queries.GetAll;

namespace SFC.Team.Api.Infrastructure.Models.Team.Player.GetAll;

/// <summary>
/// **Get** all team players response.
/// </summary>
public class GetAllTeamPlayersResponse :
    BaseErrorResponse, IMapFrom<GetAllTeamPlayersViewModel>
{
    /// <summary>
    /// Team player models.
    /// </summary>
    public IEnumerable<TeamPlayerModel> TeamPlayers { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetAllTeamPlayersViewModel, GetAllTeamPlayersResponse>()
                                                   .IgnoreAllNonExisting();
}