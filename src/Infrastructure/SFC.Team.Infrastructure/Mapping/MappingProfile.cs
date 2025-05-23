using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Team.Application.Common.Dto.Identity;
using SFC.Team.Application.Common.Dto.Player.General;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Base;
using SFC.Team.Application.Features.Data.Commands.Reset;
using SFC.Team.Application.Features.Data.Common.Dto;
using SFC.Team.Application.Features.Identity.Commands.Create;
using SFC.Team.Application.Features.Identity.Commands.CreateRange;
using SFC.Team.Application.Features.Invite.Data.Commands.Reset;
using SFC.Team.Application.Features.Invite.Data.Common.Dto;
using SFC.Team.Application.Features.Player.Commands.Create;
using SFC.Team.Application.Features.Player.Commands.CreateRange;
using SFC.Team.Application.Features.Player.Commands.Update;
using SFC.Team.Application.Features.Request.Data.Commands.Reset;
using SFC.Team.Application.Features.Request.Data.Common.Dto;
using SFC.Team.Application.Features.Team.Player.Commands.Create;
using SFC.Team.Domain.Entities.Team.Data;
using SFC.Team.Domain.Entities.Team.General;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Infrastructure.Mapping;
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

        CreateMap<Timestamp, DateTime>()
           .ConvertUsing(value => value.ToDateTime());

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        #endregion Simple types        

        #region Data

        // messages        
        CreateMapDataMessages();

        #endregion Data

        #region Identity

        // messages        
        CreateMapIdentityMessages();

        // contracts        
        CreateMapIdentityContracts();

        #endregion Identity

        #region Player

        // messages
        CreateMapPlayerMessages();

        // contracts
        CreateMapPlayerContracts();

        #endregion Player

        #region Invite

        // messages
        CreateMapInviteMessages();

        #endregion Invite

        #region Request

        // messages
        CreateMapRequestMessages();

        #endregion Request

        #region Scheme

        // messages
        CreateMapSchemeMessages();

        #endregion Scheme

        #region Team

        // messages
        CreateMapTeamMessages();

        #endregion Team
    }

    #region Data

    private void CreateMapDataMessages()
    {
        CreateMap<SFC.Data.Messages.Events.Data.DataInitialized, ResetDataCommand>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, ShirtDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, FootballPositionDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, GameStyleDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, StatCategoryDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, StatSkillDto>();
        CreateMap<SFC.Data.Messages.Models.Data.StatTypeDataValue, StatTypeDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, WorkingFootDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, RequestStatusDto>();
    }

    #endregion Data    

    #region Identity

    private void CreateMapIdentityMessages()
    {
        CreateMap<SFC.Identity.Messages.Events.User.UserCreated, CreateUserCommand>().IgnoreAllNonExisting();
        CreateMap<IEnumerable<SFC.Identity.Messages.Models.User.User>, CreateUsersCommand>()
            .ForMember(p => p.Users, d => d.MapFrom(z => z));
        CreateMap<SFC.Identity.Messages.Models.User.User, UserDto>();
    }

    private void CreateMapIdentityContracts()
    {
        CreateMap<Guid, SFC.Identity.Contracts.Messages.User.Get.GetUserRequest>()
            .ConvertUsing(id => new SFC.Identity.Contracts.Messages.User.Get.GetUserRequest { Id = id.ToString() });
        CreateMap<SFC.Identity.Contracts.Models.User.User, UserDto>();
    }

    #endregion Identity

    #region Player

    private void CreateMapPlayerMessages()
    {
        CreateMap<SFC.Player.Messages.Events.Player.General.PlayerCreated, CreatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.Player.General.PlayerUpdated, UpdatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.Player.General.PlayerUpdated, CreatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<IEnumerable<SFC.Player.Messages.Models.Player.Player>, CreatePlayersCommand>()
            .ForMember(p => p.Players, d => d.MapFrom(z => z));

        CreateMap<SFC.Player.Messages.Commands.Player.SeedPlayers, CreatePlayersCommand>();

        CreateMap<SFC.Player.Messages.Models.Player.Player, PlayerDto>()
            .ForPath(p => p.Stats.Values, d => d.MapFrom(z => z.Stats))
            .ForPath(p => p.Stats.Points, d => d.MapFrom(z => z.Points))
            .ForPath(p => p.Profile.General, d => d.MapFrom(z => z.GeneralProfile))
            .ForPath(p => p.Profile.Football, d => d.MapFrom(z => z.FootballProfile))
            .ForPath(p => p.Profile.General.Photo, d => d.MapFrom(z => z.Photo))
            .ForPath(p => p.Profile.General.Availability, d => d.MapFrom(z => z.Availability))
            .ForPath(p => p.Profile.General.Tags, d => d.MapFrom(z => z.Tags));

        // stats
        CreateMap<SFC.Player.Messages.Models.Player.PlayerStat, PlayerStatValueDto>()
            .ForPath(p => p.Type, d => d.MapFrom(z => z.TypeId));
        CreateMap<SFC.Player.Messages.Models.Player.PlayerStatPoints, PlayerStatPointsDto>();

        // general profile
        CreateMap<SFC.Player.Messages.Models.Player.PlayerGeneralProfile, PlayerGeneralProfileDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerPhoto, PlayerPhotoDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerAvailability, PlayerAvailabilityDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerAvailableDay, DayOfWeek>().ConvertUsing(day => day.Day);
        CreateMap<SFC.Player.Messages.Models.Player.PlayerTag, string>().ConvertUsing(tag => tag.Value);

        // football profile
        CreateMap<SFC.Player.Messages.Models.Player.PlayerFootballProfile, PlayerFootballProfileDto>()
            .ForPath(p => p.AdditionalPosition, d => d.MapFrom(z => z.AdditionalPositionId))
            .ForPath(p => p.Position, d => d.MapFrom(z => z.PositionId))
            .ForPath(p => p.GameStyle, d => d.MapFrom(z => z.GameStyleId))
            .ForPath(p => p.WorkingFoot, d => d.MapFrom(z => z.WorkingFootId));
    }

    private void CreateMapPlayerContracts()
    {
        CreateMap<long, SFC.Player.Contracts.Messages.Player.General.Get.GetPlayerRequest>()
            .ConvertUsing(id => new SFC.Player.Contracts.Messages.Player.General.Get.GetPlayerRequest { Id = id });
        CreateMap<SFC.Player.Contracts.Models.Player.General.Player, PlayerDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerProfile, PlayerProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerGeneralProfile, PlayerGeneralProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerAvailability, PlayerAvailabilityDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerFootballProfile, PlayerFootballProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerStats, PlayerStatsDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerStatPoints, PlayerStatPointsDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerStatValue, PlayerStatValueDto>();
    }

    #endregion Player

    #region Invite

    private void CreateMapInviteMessages()
    {
        // data
        // events
        CreateMap<SFC.Invite.Messages.Events.Invite.Data.DataInitialized, ResetInviteDataCommand>();
        // models
        CreateMap<TeamPlayerStatus, SFC.Invite.Messages.Models.Data.DataValue>();
        CreateMap<SFC.Invite.Messages.Models.Data.DataValue, InviteStatusDto>();

        // domain
        // team player
        // events
        CreateMap<SFC.Invite.Messages.Events.Invite.Team.Player.TeamPlayerInviteUpdated, CreateTeamPlayerCommand>()
            .ForMember(p => p.TeamPlayer, d => d.MapFrom(z => z.Invite));
        // models
        CreateMap<SFC.Invite.Messages.Models.Invite.Team.Player.TeamPlayerInvite, CreateTeamPlayerDto>();
    }

    #endregion Invite

    #region Request

    private void CreateMapRequestMessages()
    {
        // data
        // events
        CreateMap<SFC.Request.Messages.Events.Request.Data.DataInitialized, ResetRequestDataCommand>();
        // models
        CreateMap<TeamPlayerStatus, SFC.Request.Messages.Models.Data.DataValue>();
        CreateMap<SFC.Request.Messages.Models.Data.DataValue, RequestStatusDto>();

        // domain
        // team player
        // events
        CreateMap<SFC.Request.Messages.Events.Request.Team.Player.TeamPlayerRequestUpdated, CreateTeamPlayerCommand>()
            .ForMember(p => p.TeamPlayer, d => d.MapFrom(z => z.Request));
        // models
        CreateMap<SFC.Request.Messages.Models.Request.Team.Player.TeamPlayerRequest, CreateTeamPlayerDto>();
    }

    #endregion Request

    #region Scheme

    private void CreateMapSchemeMessages()
    {
        // data
        // events
        // models
        CreateMap<TeamPlayerStatus, SFC.Scheme.Messages.Models.Data.DataValue>();
    }

    #endregion Scheme

    #region Team

    private void CreateMapTeamMessages()
    {
        // data
        // commands
        CreateMap<SFC.Team.Messages.Commands.Invite.Data.InitializeData, ResetInviteDataCommand>();
        CreateMap<SFC.Team.Messages.Commands.Request.Data.InitializeData, ResetRequestDataCommand>();
        CreateMap<SFC.Team.Messages.Commands.Data.InitializeData, ResetDataCommand>();
        // models
        CreateMap<SFC.Team.Messages.Models.Data.DataValue, ShirtDto>();
        CreateMap<SFC.Team.Messages.Models.Data.DataValue, FootballPositionDto>();
        CreateMap<SFC.Team.Messages.Models.Data.DataValue, GameStyleDto>();
        CreateMap<SFC.Team.Messages.Models.Data.DataValue, StatCategoryDto>();
        CreateMap<SFC.Team.Messages.Models.Data.DataValue, StatSkillDto>();
        CreateMap<SFC.Team.Messages.Models.Data.StatTypeDataValue, StatTypeDto>();
        CreateMap<SFC.Team.Messages.Models.Data.DataValue, WorkingFootDto>();
        CreateMap<SFC.Team.Messages.Models.Data.DataValue, RequestStatusDto>();
        CreateMap<SFC.Team.Messages.Models.Data.DataValue, InviteStatusDto>();

        // team data
        CreateMap<TeamPlayerStatus, SFC.Team.Messages.Models.Data.DataValue>();

        //team
        // events
        CreateMap<IEnumerable<TeamEntity>, SFC.Team.Messages.Events.Team.General.TeamsSeeded>()
            .ForMember(p => p.Teams, d => d.MapFrom(z => z));
        CreateMap<TeamEntity, SFC.Team.Messages.Events.Team.General.TeamCreated>()
            .ForMember(p => p.Team, d => d.MapFrom(z => z));
        CreateMap<TeamEntity, SFC.Team.Messages.Events.Team.General.TeamUpdated>()
            .ForMember(p => p.Team, d => d.MapFrom(z => z));
        // commands        
        CreateMap<IEnumerable<TeamEntity>, SFC.Team.Messages.Commands.Team.General.SeedTeams>()
            .ForMember(p => p.Teams, d => d.MapFrom(z => z));
        // models        
        CreateMap<TeamEntity, SFC.Team.Messages.Models.Team.General.Team>();
        CreateMap<TeamAvailability, SFC.Team.Messages.Models.Team.General.TeamAvailability>();
        CreateMap<TeamFinancialProfile, SFC.Team.Messages.Models.Team.General.TeamFinancialProfile>();
        CreateMap<TeamGeneralProfile, SFC.Team.Messages.Models.Team.General.TeamGeneralProfile>();
        CreateMap<TeamLogo, SFC.Team.Messages.Models.Team.General.TeamLogo>();
        CreateMap<TeamShirt, SFC.Team.Messages.Models.Team.General.TeamShirt>();
        CreateMap<TeamTag, SFC.Team.Messages.Models.Team.General.TeamTag>();

        // team player
        // events
        CreateMap<IEnumerable<TeamPlayer>, SFC.Team.Messages.Events.Team.Player.TeamPlayersSeeded>()
            .ForMember(p => p.TeamPlayers, d => d.MapFrom(z => z));
        CreateMap<TeamPlayer, SFC.Team.Messages.Events.Team.Player.TeamPlayerUpdated>()
            .ForMember(p => p.TeamPlayer, d => d.MapFrom(z => z));
        CreateMap<TeamPlayer, SFC.Team.Messages.Events.Team.Player.TeamPlayerCreated>()
            .ForMember(p => p.TeamPlayer, d => d.MapFrom(z => z));
        // commands
        CreateMap<IEnumerable<TeamPlayer>, SFC.Team.Messages.Commands.Team.Player.SeedTeamPlayers>()
            .ForMember(p => p.TeamPlayers, d => d.MapFrom(z => z));
        // models
        CreateMap<TeamPlayer, SFC.Team.Messages.Models.Team.Player.TeamPlayer>();
    }

    #endregion Team
}