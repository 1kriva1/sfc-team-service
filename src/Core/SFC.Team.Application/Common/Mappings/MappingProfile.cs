using System.Reflection;

using SFC.Team.Application.Common.Mappings.Base;
using SFC.Team.Application.Features.Common.Dto.Pagination;
using SFC.Team.Application.Features.Common.Models.Find.Paging;
using SFC.Team.Application.Features.Team.Data.Queries.Common.Dto;
using SFC.Team.Domain.Common;
using SFC.Team.Domain.Entities.Data;
using SFC.Team.Domain.Entities.Identity;
using SFC.Team.Domain.Entities.Player;
using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Application.Common.Mappings;
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

        CreateMap<TeamShirt, int>()
            .ConvertUsing(teamShirt => (int)teamShirt.ShirtId);
        CreateMap<int, TeamShirt>()
            .ConvertUsing(shirtId => new TeamShirt { ShirtId = (ShirtEnum)shirtId });

        CreateMap<string, TeamTag>()
            .ConvertUsing(tag => new TeamTag { Value = tag });
        CreateMap<TeamTag, string>()
            .ConvertUsing(tag => tag.Value);

        CreateMap<int, StatType>()
            .ConvertUsing(statType => new StatType { Id = (StatTypeEnum)statType });
        CreateMap<StatType, int>()
            .ConvertUsing(statType => (int)statType.Id);

        CreateMap<DayOfWeek, PlayerAvailableDay>()
            .ConvertUsing(day => new PlayerAvailableDay { Day = day });
        CreateMap<PlayerAvailableDay, DayOfWeek>()
            .ConvertUsing(day => day.Day);

        CreateMap<string, PlayerTag>()
            .ConvertUsing(tag => new PlayerTag { Value = tag });
        CreateMap<PlayerTag, string>()
            .ConvertUsing(tag => tag.Value);

        CreateMap<Guid, User>()
            .ConvertUsing(id => new User { Id = id });

        #endregion Simple types

        #region Generic types

        CreateMap(typeof(PagedList<>), typeof(PageDto<>))
            .ForMember(nameof(PageDto<object>.Items), d => d.Ignore())
            .ForMember(nameof(PageDto<object>.Metadata), d => d.Ignore());

        CreateMap(typeof(PagedList<>), typeof(PageMetadataDto));

        CreateMap(typeof(EnumDataEntity<>), typeof(DataValueDto));

        #endregion Generic types

        #region Complex types

        #endregion Complex types
    }
}