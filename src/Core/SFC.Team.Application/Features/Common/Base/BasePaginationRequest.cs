using SFC.Team.Application.Features.Common.Dto.Common;
using SFC.Team.Application.Features.Common.Dto.Pagination;

namespace SFC.Team.Application.Features.Common.Base;
public abstract class BasePaginationRequest<TResponse, TFilter> : Request<TResponse>
{
    public PaginationDto Pagination { get; set; } = default!;

    public IEnumerable<SortingDto> Sorting { get; set; } = [];

    public TFilter Filter { get; set; } = default!;
}