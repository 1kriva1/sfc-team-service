using AutoMapper;

using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Converters.File;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Common.Dto.Common;
using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Application.Features.Team.General.Common.Dto;
public class TeamLogoDto : FileDto, IMapFromReverse<TeamLogo>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamLogo, TeamLogoDto>();

        profile.CreateMap<string?, TeamLogoDto?>()
               .ConvertUsing<Base64StringToFileTypeConverter<TeamLogoDto>>();

        profile.CreateMap<TeamLogoDto?, string?>()
               .ConvertUsing<FileToBase64StringTypeConverter<TeamLogoDto>>();

        profile.CreateMap<TeamLogoDto, TeamLogo>()
               .IgnoreAllNonExisting();
    }
}