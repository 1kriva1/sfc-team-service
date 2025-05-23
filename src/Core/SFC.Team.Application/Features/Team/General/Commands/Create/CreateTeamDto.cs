using AutoMapper;

using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Common.Dto;

namespace SFC.Team.Application.Features.Team.General.Commands.Create;
public class CreateTeamDto : BaseTeamDto, IMapTo<TeamEntity>
{
    public new void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTeamDto, TeamEntity>()
               .IncludeBase<BaseTeamDto, TeamEntity>();
    }
}