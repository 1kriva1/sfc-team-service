namespace SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;
public class GetTeamsGeneralProfileFilterDto
{
    public string? Name { get; set; }

    public string? City { get; set; }

    public IEnumerable<string>? Tags { get; set; }

    public GetTeamsAvailabilityLimitDto? Availability { get; set; }

    public long? LocationId { get; set; }

    public bool? HasLogo { get; set; }
}