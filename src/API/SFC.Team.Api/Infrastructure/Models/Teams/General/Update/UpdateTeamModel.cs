using SFC.Team.Api.Infrastructure.Models.Teams.General.Common;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Commands.Update;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Update;

/// <summary>
/// **Update** team model.
/// </summary>
public class UpdateTeamModel : BaseTeamModel, IMapTo<UpdateTeamDto> { }