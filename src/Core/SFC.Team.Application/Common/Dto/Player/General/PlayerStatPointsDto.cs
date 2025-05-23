using AutoMapper;

using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities;
using SFC.Team.Domain.Entities.Player;

namespace SFC.Team.Application.Common.Dto.Player.General;

public record PlayerStatPointsDto : IMapFromReverse<PlayerStatPoints>
{
    public int Available { get; set; }

    public int Used { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerStatPointsDto, PlayerStatPoints>()
               .ReverseMap()
               .IgnoreAllNonExisting();
    }
}