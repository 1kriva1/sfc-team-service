using AutoMapper;

using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Converters.File;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Common.Dto.Common;
using SFC.Team.Domain.Entities.Player;

namespace SFC.Team.Application.Common.Dto.Player.General;
public class PlayerPhotoDto : FileDto, IMapFromReverse<PlayerPhoto>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerPhoto, PlayerPhotoDto>();

        profile.CreateMap<string?, PlayerPhotoDto?>()
               .ConvertUsing<Base64StringToFileTypeConverter<PlayerPhotoDto>>();

        profile.CreateMap<PlayerPhotoDto?, string?>()
               .ConvertUsing<FileToBase64StringTypeConverter<PlayerPhotoDto>>();

        profile.CreateMap<PlayerPhotoDto, PlayerPhoto>()
               .IgnoreAllNonExisting();
    }
}