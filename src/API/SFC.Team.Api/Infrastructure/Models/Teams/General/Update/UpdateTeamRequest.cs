using AutoMapper;

using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Commands.Update;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Update;

/// <summary>
/// **Update** team request.
/// </summary>
public class UpdateTeamRequest : IMapTo<UpdateTeamCommand>
{
    /// <summary>
    /// Team model.
    /// </summary>
    public UpdateTeamModel Team { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateTeamRequest, UpdateTeamCommand>()
                                                   .IgnoreAllNonExisting();
}