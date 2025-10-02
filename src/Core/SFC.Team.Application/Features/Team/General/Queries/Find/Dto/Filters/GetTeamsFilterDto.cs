namespace SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;
public class GetTeamsFilterDto
{
    public IEnumerable<int> Statuses { get; set; } = [];

    public GetTeamsProfileFilterDto? Profile { get; set; }
}