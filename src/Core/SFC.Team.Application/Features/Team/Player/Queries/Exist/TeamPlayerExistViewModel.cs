using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Queries.Exist;
public class TeamPlayerExistViewModel : IMapFrom<bool>
{
    public bool Exist { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<bool, TeamPlayerExistViewModel>()
               .ConvertUsing(exist => new TeamPlayerExistViewModel { Exist = exist });
    }
}