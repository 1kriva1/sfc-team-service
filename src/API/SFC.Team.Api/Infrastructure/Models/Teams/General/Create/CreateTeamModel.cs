using SFC.Team.Api.Infrastructure.Models.Teams.General.Common;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Commands.Create;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Create;

/// <summary>
/// **Create** team model.
/// </summary>
public class CreateTeamModel : BaseTeamModel, IMapTo<CreateTeamDto> { }