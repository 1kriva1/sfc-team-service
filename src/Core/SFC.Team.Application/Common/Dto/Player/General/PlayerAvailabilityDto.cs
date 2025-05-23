using AutoMapper;

using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities;
using SFC.Team.Domain.Entities.Player;

namespace SFC.Team.Application.Common.Dto.Player.General;

public record PlayerAvailabilityDto : IMapFromReverse<PlayerAvailability>
{
    public TimeSpan? From { get; set; }

    public TimeSpan? To { get; set; }

    public IEnumerable<DayOfWeek> Days { get; set; } = [];

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerAvailabilityDto, PlayerAvailability>()
               .ReverseMap()
               .IgnoreAllNonExisting();
    }
}