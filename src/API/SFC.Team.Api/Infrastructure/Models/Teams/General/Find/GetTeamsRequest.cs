using AutoMapper;

using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Teams.General.Find.Filters;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Find;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Find;

/// <summary>
/// **Get** teams request.
/// </summary>
public class GetTeamsRequest : BasePaginationRequest<GetTeamsFilterModel>, IMapTo<GetTeamsQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetTeamsRequest, GetTeamsQuery>()
                                                   .IgnoreAllNonExisting();
}