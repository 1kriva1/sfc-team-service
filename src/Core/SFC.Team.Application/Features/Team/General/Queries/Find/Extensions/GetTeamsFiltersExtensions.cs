using SFC.Team.Application.Features.Common.Models.Find.Filters;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Application.Features.Team.General.Queries.Find.Extensions;
public static class GetTeamsFiltersExtensions
{
    public static IEnumerable<Filter<TeamEntity>> BuildSearchFilters(this GetTeamsFilterDto filter)
    {
        return [
            // general profile
            new()
            {
                Condition = !string.IsNullOrEmpty(filter?.Profile?.General?.Name),
                Expression = team => team.GeneralProfile.Name.Contains(filter!.Profile!.General!.Name!)
            },
            new()
            {
                Condition = !string.IsNullOrEmpty(filter?.Profile?.General?.City),
                Expression = team => team.GeneralProfile.City.Contains(filter!.Profile!.General!.City!)
            },
            new()
            {
                Condition = filter?.Profile?.General?.Tags?.Any() ?? false,
                Expression = team => team.Tags.Any(tag => filter!.Profile!.General!.Tags!.Contains(tag.Value))
            },
            new()
            {
                Condition = (filter?.Profile?.General?.Availability?.From.HasValue ?? false)
                    && (filter.Profile.General?.Availability!.To == null || filter.Profile.General.Availability.From <= filter.Profile.General.Availability.To),
                Expression = team => team.Availability.Any(availability => availability.From <= filter!.Profile!.General!.Availability!.From
                    && filter!.Profile!.General!.Availability!.Days.Contains(availability.Day))
            },
            new()
            {
                Condition = (filter?.Profile?.General?.Availability?.To.HasValue ?? false)
                    && (filter.Profile.General.Availability.From == null || filter.Profile.General.Availability.To >= filter.Profile.General.Availability.From),
                Expression = team => team.Availability.Any(availability => availability.To >= filter!.Profile!.General!.Availability!.To
                    && filter!.Profile!.General!.Availability!.Days.Contains(availability.Day))
            },
            new()
            {
                Condition = filter?.Profile?.General?.Availability?.Days?.Any() ?? false,
                Expression = team => team.Availability.Any(availability => filter!.Profile!.General!.Availability!.Days.Contains(availability.Day))
            },
            new()
            {
                Condition = filter?.Profile?.General?.HasLogo.HasValue ?? false,
                Expression = team => filter!.Profile!.General!.HasLogo!.Value && team.Logo != null && team.Logo.Size > 0
                    || !filter.Profile.General!.HasLogo!.Value && (team.Logo == null || team.Logo.Size <= 0)
            },
            new()
            {
                Condition = filter?.Profile?.General?.LocationId.HasValue ?? false,
                Expression = team => team.GeneralProfile.LocationId == filter!.Profile!.General!.LocationId
            },
            // financial profile
            new()
            {
                Condition = filter?.Profile?.Financial?.FreePlay.HasValue ?? false,
                Expression = team => team.FinancialProfile.FreePlay == filter!.Profile!.Financial!.FreePlay
            },
            // inventary profile
            new()
            {
                Condition = filter?.Profile?.Inventary?.Shirts?.Any() ?? false,
                Expression = team => team.Shirts.Any(shirt => filter!.Profile!.Inventary!.Shirts.Contains((int)shirt.ShirtId))
            }
        ];
    }
}