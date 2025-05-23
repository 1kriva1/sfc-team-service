using AutoMapper;

using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Commands.Create;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Create;

/// <summary>
/// **Create** team request.
/// </summary>
public class CreateTeamRequest : IMapTo<CreateTeamCommand>
{
    /// <summary>
    /// Team model.
    /// </summary>
    public CreateTeamModel Team { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamRequest, CreateTeamCommand>()
                                                   .IgnoreAllNonExisting();
}