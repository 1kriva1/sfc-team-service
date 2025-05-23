using AutoMapper;

using SFC.Team.Api.Infrastructure.Models.Base;
using SFC.Team.Api.Infrastructure.Models.Teams.General.Common;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Find;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Find;

/// <summary>
/// **Get** teams response.
/// </summary>
public class GetTeamsResponse : BaseListResponse<TeamModel>, IMapFrom<GetTeamsViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetTeamsViewModel, GetTeamsResponse>()
                                                   .IgnoreAllNonExisting();
}