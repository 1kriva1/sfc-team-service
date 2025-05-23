using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Common.Base;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Application.Features.Team.General.Queries.Find;
public class GetTeamsQuery : BasePaginationRequest<GetTeamsViewModel, GetTeamsFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetTeams; }
}