namespace SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;
public class GetTeamsProfileFilterDto
{
    public GetTeamsGeneralProfileFilterDto? General { get; set; }

    public GetTeamsFinancialProfileFilterDto? Financial { get; set; }

    public GetTeamsInventaryProfileFilterDto? Inventary { get; set; }
}