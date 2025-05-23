using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Common.Base;

namespace SFC.Team.Application.Features.Team.Data.Queries.GetAll;

public class GetAllTeamDataQuery : Request<GetAllTeamDataViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAllTeamData; }
}