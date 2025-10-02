using SFC.Team.Application.Features.Common.Models.Find.Filters;
using SFC.Team.Application.Features.Common.Models.Find.Paging;
using SFC.Team.Application.Features.Common.Models.Find.Sorting;

namespace SFC.Team.Application.Features.Common.Models.Find;
public class FindParameters<T>
{
    public Filters<T>? Filters { get; set; }

    public Sortings<T>? Sorting { get; set; }

    public required Pagination Pagination { get; set; }
}