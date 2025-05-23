using AutoMapper;

using MediatR;

using SFC.Team.Application.Features.Common.Dto.Pagination;
using SFC.Team.Application.Features.Common.Models;
using SFC.Team.Application.Features.Common.Models.Filters;
using SFC.Team.Application.Features.Common.Models.Find.Filters;
using SFC.Team.Application.Features.Common.Models.Find.Paging;
using SFC.Team.Application.Features.Common.Models.Find.Sorting;
using SFC.Team.Application.Features.Common.Models.Sorting;
using SFC.Team.Application.Features.Team.Player.Common.Dto;
using SFC.Team.Application.Features.Team.Player.Queries.Find.Extensions;
using SFC.Team.Application.Interfaces.Common;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Queries.Find;
public class GetTeamPlayersQueryHandler(
    IMapper mapper,
    ITeamPlayerRepository teamPlayerRepository,
    IDateTimeService dateTimeService)
    : IRequestHandler<GetTeamPlayersQuery, GetTeamPlayersViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRepository _teamPlayerRepository = teamPlayerRepository;
    private readonly IDateTimeService _dateTimeService = dateTimeService;

    public async Task<GetTeamPlayersViewModel> Handle(GetTeamPlayersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<TeamPlayer>> filters = request.Filter.BuildSearchFilters(_dateTimeService.DateNow);

        IEnumerable<Sorting<TeamPlayer, dynamic>> sorting = request.Sorting.BuildTeamPlayerSorting();

        FindParameters<TeamPlayer> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<TeamPlayer>(filters),
            Sorting = new Sortings<TeamPlayer>(sorting)
        };

        PagedList<TeamPlayer> pageList = await _teamPlayerRepository.FindAsync(parameters)
                                                                    .ConfigureAwait(true);

        return new GetTeamPlayersViewModel
        {
            Items = _mapper.Map<IEnumerable<TeamPlayerDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}