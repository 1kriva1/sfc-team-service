using AutoMapper;

using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Teams.General.Common;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Commands.Create;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Create;

/// <summary>
/// **Create** team response model.
/// </summary>
public class CreateTeamResponse :
    BaseErrorResponse, IMapFrom<CreateTeamViewModel>
{
    /// <summary>
    /// Team model.
    /// </summary>
    public TeamModel Team { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamViewModel, CreateTeamResponse>()
                                                   .IgnoreAllNonExisting();
}