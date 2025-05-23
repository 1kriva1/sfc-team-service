using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Team.Api.Infrastructure.Models.Common;
using SFC.Team.Api.Infrastructure.Models.Teams.Players.Common;
using SFC.Team.Application.Common.Mappings.Base;
using SFC.Team.Application.Features.Common.Dto.Common;
using SFC.Team.Application.Features.Common.Dto.Pagination;
using SFC.Team.Application.Features.Team.Data.Queries.Common.Dto;
using SFC.Team.Application.Features.Team.Data.Queries.GetAll;
using SFC.Team.Application.Features.Team.General.Common.Dto;
using SFC.Team.Application.Features.Team.General.Queries.Find;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;
using SFC.Team.Application.Features.Team.General.Queries.Get;
using SFC.Team.Application.Features.Team.Player.Common.Dto;
using SFC.Team.Application.Features.Team.Player.Queries.Find;
using SFC.Team.Application.Features.Team.Player.Queries.Find.Dto.Filters;
using SFC.Team.Application.Features.Team.Player.Queries.Get;

namespace SFC.Team.Api.Infrastructure.Mappings;

public class MappingProfile : BaseMappingProfile
{
    protected override Assembly Assembly => Assembly.GetExecutingAssembly();

    public MappingProfile() : base()
    {
        ApplyCustomMappings();
    }

    private void ApplyCustomMappings()
    {
        #region Simple types

        CreateMap<DateTime, Timestamp>()
           .ConvertUsing(value => DateTime.SpecifyKind(value, DateTimeKind.Utc).ToTimestamp());

        CreateMap<TimeSpan, Duration>()
            .ConvertUsing(value => Duration.FromTimeSpan(value));

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        CreateMap<long, TeamPlayerTeamModel>()
            .ConvertUsing(teamId => new TeamPlayerTeamModel { Id = teamId });

        #endregion Simple types

        #region Generic types

        CreateMap(typeof(RangeLimitModel<>), typeof(RangeLimitDto<>));

        #endregion Generic types

        #region Complex types

        #region Team

        // data
        CreateMapTeamDataContracts();

        // team contracts
        CreateMapTeamContracts();

        #endregion Team

        #endregion Complex types
    }

    #region Team

    private void CreateMapTeamDataContracts()
    {
        CreateMap<DataValueDto, SFC.Team.Contracts.Models.Team.Data.DataValue>();
        CreateMap<GetAllTeamDataViewModel, SFC.Team.Contracts.Messages.Team.Data.GetAll.GetAllTeamDataResponse>();
    }

    private void CreateMapTeamContracts()
    {
        // get team
        CreateMap<SFC.Team.Contracts.Messages.Team.General.Get.GetTeamRequest, GetTeamQuery>()
             .ForMember(p => p.TeamId, d => d.MapFrom(z => z.Id));
        CreateMap<GetTeamViewModel, SFC.Team.Contracts.Messages.Team.General.Get.GetTeamResponse>();
        CreateMap<TeamDto, SFC.Team.Contracts.Headers.AuditableHeader>();

        // get teams
        // (filters)
        CreateMap<SFC.Team.Contracts.Messages.Team.General.Find.GetTeamsRequest, GetTeamsQuery>();
        CreateMap<SFC.Team.Contracts.Models.Common.Pagination, PaginationDto>();
        CreateMap<SFC.Team.Contracts.Models.Common.Sorting, SortingDto>();
        CreateMap<SFC.Team.Contracts.Messages.Team.General.Find.Filters.TeamsFilter, GetTeamsFilterDto>();
        CreateMap<SFC.Team.Contracts.Messages.Team.General.Find.Filters.TeamsProfileFilter, GetTeamsProfileFilterDto>();
        CreateMap<SFC.Team.Contracts.Messages.Team.General.Find.Filters.TeamsGeneralProfileFilter, GetTeamsGeneralProfileFilterDto>();
        CreateMap<SFC.Team.Contracts.Messages.Team.General.Find.Filters.TeamsAvailabilityLimit, GetTeamsAvailabilityLimitDto>();
        CreateMap<SFC.Team.Contracts.Messages.Team.General.Find.Filters.TeamsFinancialProfileFilter, GetTeamsFinancialProfileFilterDto>();
        CreateMap<SFC.Team.Contracts.Messages.Team.General.Find.Filters.TeamsInventaryProfileFilter, GetTeamsInventaryProfileFilterDto>();
        // (result)
        CreateMap<GetTeamsViewModel, SFC.Team.Contracts.Messages.Team.General.Find.GetTeamsResponse>();
        // (headers)
        CreateMap<PageMetadataDto, SFC.Team.Contracts.Headers.PaginationHeader>();

        // team
        CreateMap<TeamDto, SFC.Team.Contracts.Models.Team.General.Team>();
        CreateMap<TeamProfileDto, SFC.Team.Contracts.Models.Team.General.TeamProfile>();
        CreateMap<TeamGeneralProfileDto, SFC.Team.Contracts.Models.Team.General.TeamGeneralProfile>();
        CreateMap<TeamAvailabilityDto, SFC.Team.Contracts.Models.Team.General.TeamAvailability>();
        CreateMap<TeamFinancialProfileDto, SFC.Team.Contracts.Models.Team.General.TeamFinancialProfile>();
        CreateMap<TeamInventaryProfileDto, SFC.Team.Contracts.Models.Team.General.TeamInventaryProfile>();

        // get team player
        CreateMap<SFC.Team.Contracts.Messages.Team.Player.Get.GetTeamPlayerRequest, GetTeamPlayerQuery>();
        CreateMap<GetTeamPlayerViewModel, SFC.Team.Contracts.Messages.Team.Player.Get.GetTeamPlayerResponse>();
        CreateMap<TeamPlayerDto, SFC.Team.Contracts.Headers.AuditableHeader>();

        // get team players
        // (filters)
        CreateMap<SFC.Team.Contracts.Messages.Team.Player.Find.GetTeamPlayersRequest, GetTeamPlayersQuery>();
        CreateMap<SFC.Team.Contracts.Messages.Team.Player.Find.Filters.TeamPlayersFilter, GetTeamPlayersFilterDto>();
        CreateMap<SFC.Team.Contracts.Messages.Team.Player.Find.Filters.TeamPlayerFilter, GetTeamPlayersTeamPlayerFilterDto>();
        // (result)
        CreateMap<GetTeamPlayersViewModel, SFC.Team.Contracts.Messages.Team.Player.Find.GetTeamPlayersResponse>();

        // team player
        CreateMap<TeamPlayerDto, SFC.Team.Contracts.Models.Team.Player.TeamPlayer>();
    }

    #endregion Team
}