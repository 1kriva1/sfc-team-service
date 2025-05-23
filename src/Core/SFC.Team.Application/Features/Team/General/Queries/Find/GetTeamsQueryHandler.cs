using AutoMapper;

using MediatR;

using SFC.Team.Application.Features.Common.Dto.Pagination;
using SFC.Team.Application.Features.Common.Models;
using SFC.Team.Application.Features.Common.Models.Filters;
using SFC.Team.Application.Features.Common.Models.Find.Filters;
using SFC.Team.Application.Features.Common.Models.Find.Paging;
using SFC.Team.Application.Features.Common.Models.Find.Sorting;
using SFC.Team.Application.Features.Common.Models.Sorting;
using SFC.Team.Application.Features.Team.General.Common.Dto;
using SFC.Team.Application.Features.Team.General.Queries.Find.Extensions;
using SFC.Team.Application.Interfaces.Common;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;

namespace SFC.Team.Application.Features.Team.General.Queries.Find;
public record GetTeamsQueryHandler(
    IMapper Mapper,
    ITeamRepository TeamRepository,
    IUriService UriService,
    IMediator Mediator)
    : IRequestHandler<GetTeamsQuery, GetTeamsViewModel>
{
    public async Task<GetTeamsViewModel> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<TeamEntity>> filters = request.Filter.BuildSearchFilters();

        IEnumerable<Sorting<TeamEntity, dynamic>>? sorting = request.Sorting.BuildTeamSearchSorting();

        FindParameters<TeamEntity> parameters = new()
        {
            Pagination = Mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<TeamEntity>(filters),
            Sorting = sorting != null
                ? new Sortings<TeamEntity>(sorting)
                : new Sortings<TeamEntity>()
        };

        PagedList<TeamEntity> pageList = await TeamRepository.FindAsync(parameters)
                                                             .ConfigureAwait(true);

        return new GetTeamsViewModel
        {
            Items = Mapper.Map<IEnumerable<TeamDto>>(pageList),
            Metadata = Mapper.Map<PageMetadataDto>(pageList)
        };
    }
}