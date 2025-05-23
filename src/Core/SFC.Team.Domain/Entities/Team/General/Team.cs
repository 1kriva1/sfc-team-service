using SFC.Team.Domain.Common;
using SFC.Team.Domain.Common.Interfaces;

namespace SFC.Team.Domain.Entities.Team.General;
public class Team : BaseAuditableEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public required TeamGeneralProfile GeneralProfile { get; set; }

    public required TeamFinancialProfile FinancialProfile { get; set; }

    public TeamLogo? Logo { get; set; }

    public ICollection<TeamAvailability> Availability { get; } = [];

    public ICollection<TeamTag> Tags { get; } = [];

    public ICollection<TeamShirt> Shirts { get; } = [];
}