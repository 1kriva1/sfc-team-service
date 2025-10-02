using AutoMapper;

using SFC.Team.Api.Infrastructure.Models.Team.Player.Common;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Common.Dto;
using SFC.Team.Application.Features.Team.Player.Common.Dto;

namespace SFC.Team.Api.Infrastructure.Models.Team.General.Common;

/// <summary>
/// Team model.
/// </summary>
public class TeamModel : BaseTeamModel, IMapFrom<TeamDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Team status.
    /// </summary>
    public int Status { get; set; }

    public IEnumerable<TeamPlayerModel> Players { get; set; } = [];

    public void Mapping(Profile profile) => profile.CreateMap<TeamDto, TeamModel>()
                                                  .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}