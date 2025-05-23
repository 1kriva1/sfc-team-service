using AutoMapper;

using SFC.Team.Api.Infrastructure.Models.Teams.Common.Player.Result;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Common.Dto;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Players.Common;

/// <summary>
/// Team player model.
/// </summary>
public class TeamPlayerModel : IMapFrom<TeamPlayerDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Team player related to this player.
    /// </summary>
    public required PlayerModel Player { get; set; }

    /// <summary>
    /// Team player related to this team.
    /// </summary>
    public required TeamPlayerTeamModel Team { get; set; }

    /// <summary>
    /// Team player status.
    /// </summary>
    public int Status { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<TeamPlayerDto, TeamPlayerModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId))
                                                   .ForMember(p => p.Team, d => d.MapFrom(z => z.TeamId));
}