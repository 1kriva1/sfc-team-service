using SFC.Team.Messages.Models.Common;

namespace SFC.Team.Messages.Models.Team.General;
public class Team : Auditable
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public required TeamGeneralProfile GeneralProfile { get; set; }

    public required TeamFinancialProfile FinancialProfile { get; set; }

    public TeamLogo? Logo { get; set; }

    public IEnumerable<TeamAvailability>? Availability { get; init; }

    public IEnumerable<TeamTag>? Tags { get; init; }

    public IEnumerable<TeamShirt>? Shirts { get; init; }
}