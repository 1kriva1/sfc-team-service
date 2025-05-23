using AutoMapper;

using SFC.Team.Application.Common.Dto.Common;
using SFC.Team.Application.Common.Mappings.Interfaces;

namespace SFC.Team.Application.Features.Team.General.Common.Dto;
public class BaseTeamDto : AuditableDto, IMapToReverse<TeamEntity>
{
    public required TeamProfileDto Profile { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<BaseTeamDto, TeamEntity>()
                .ForMember(p => p.GeneralProfile, d => d.MapFrom(z => z.Profile.General))
                .ForMember(p => p.FinancialProfile, d => d.MapFrom(z => z.Profile.Financial))
                .ForMember(p => p.Shirts, d => d.MapFrom(z => z.Profile.Inventary.Shirts))
                .ForMember(p => p.Availability, d => d.MapFrom(z => z.Profile.General.Availability))
                .ForMember(p => p.Logo, d => d.MapFrom(z => z.Profile.General.Logo))
                .ForMember(p => p.Tags, d => d.MapFrom(z => z.Profile.General.Tags))
                .ForMember(p => p.CreatedDate, d => d.Ignore())
                .ForMember(p => p.CreatedBy, d => d.Ignore())
                .ForMember(p => p.LastModifiedDate, d => d.Ignore())
                .ForMember(p => p.LastModifiedBy, d => d.Ignore())
                .ReverseMap();
    }
}