using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Application.Features.Team.General.Common.Dto;
public class TeamFinancialProfileDto : IMapFromReverse<TeamFinancialProfile>
{
    public bool FreePlay { get; set; }
}