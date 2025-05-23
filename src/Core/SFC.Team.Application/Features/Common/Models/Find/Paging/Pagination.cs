using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Common.Dto.Pagination;

namespace SFC.Team.Application.Features.Common.Models.Find.Paging;
public class Pagination : IMapFrom<PaginationDto>
{
    public int Page { get; set; }

    public int Size { get; set; }
}