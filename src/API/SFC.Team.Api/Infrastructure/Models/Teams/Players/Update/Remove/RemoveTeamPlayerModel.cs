using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Commands.Update;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Players.Update.Remove;

/// <summary>
/// **Remove** player from team model.
/// </summary>
public class RemoveTeamPlayerModel : IMapTo<UpdateTeamPlayerDto>
{
    /// <summary>
    /// Comment from team to explain why he/she is removed from team.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<RemoveTeamPlayerModel, UpdateTeamPlayerDto>()
                                                   .ForMember(p => p.TeamComment, d => d.MapFrom(z => z.Comment));
}