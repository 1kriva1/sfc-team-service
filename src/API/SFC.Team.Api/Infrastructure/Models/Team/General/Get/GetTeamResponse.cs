using AutoMapper;

using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Team.General.Common;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Get;

namespace SFC.Team.Api.Infrastructure.Models.Team.General.Get;

/// <summary>
/// **Get** team response.
/// </summary>
public class GetTeamResponse :
    BaseErrorResponse, IMapFrom<GetTeamViewModel>
{
    /// <summary>
    /// Team model.
    /// </summary>
    public TeamModel Team { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetTeamViewModel, GetTeamResponse>()
                                                   .IgnoreAllNonExisting();
}