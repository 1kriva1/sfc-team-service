using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Team.Data.Common;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Data.Queries.GetAll;

namespace SFC.Team.Api.Infrastructure.Models.Team.Data.GetAll;

/// <summary>
/// Contain all available team **data types**.
/// </summary>
public class GetAllTeamDataResponse : BaseErrorResponse, IMapFrom<GetAllTeamDataViewModel>
{
    /// <summary>
    /// Team statuses.
    /// </summary>
    public IEnumerable<DataValueModel> TeamStatuses { get; init; } = [];

    /// <summary>
    /// Team player statuses.
    /// </summary>
    public IEnumerable<DataValueModel> TeamPlayerStatuses { get; init; } = [];
}