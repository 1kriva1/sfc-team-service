﻿using AutoMapper;

using MediatR;

using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Entities.Data;
using SFC.Team.Domain.Events.Data;

namespace SFC.Team.Application.Features.Data.Commands.Reset;
public class ResetDataCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IFootballPositionRepository positionsRepository,
    IShirtRepository shirtsRepository,
    IGameStyleRepository gameStylesRepository,
    IStatCategoryRepository statCategoriesRepository,
    IStatSkillRepository statSkillsRepository,
    IStatTypeRepository statTypesRepository,
    IWorkingFootRepository workingFootsRepository) : IRequestHandler<ResetDataCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IFootballPositionRepository _positionsRepository = positionsRepository;
    private readonly IShirtRepository _shirtsRepository = shirtsRepository;
    private readonly IGameStyleRepository _gameStylesRepository = gameStylesRepository;
    private readonly IStatCategoryRepository _statCategoriesRepository = statCategoriesRepository;
    private readonly IStatSkillRepository _statSkillsRepository = statSkillsRepository;
    private readonly IStatTypeRepository _statTypesRepository = statTypesRepository;
    private readonly IWorkingFootRepository _workingFootsRepository = workingFootsRepository;

    public async Task Handle(ResetDataCommand request, CancellationToken cancellationToken)
    {
        await _shirtsRepository.ResetAsync(_mapper.Map<IEnumerable<Shirt>>(request.Shirts))
                                                .ConfigureAwait(false);

        await _positionsRepository.ResetAsync(_mapper.Map<IEnumerable<FootballPosition>>(request.FootballPositions))
                                                                         .ConfigureAwait(false);

        await _gameStylesRepository.ResetAsync(_mapper.Map<IEnumerable<GameStyle>>(request.GameStyles))
                                                            .ConfigureAwait(false);

        await _workingFootsRepository.ResetAsync(_mapper.Map<IEnumerable<WorkingFoot>>(request.WorkingFoots))
                                                                  .ConfigureAwait(false);

        await _statCategoriesRepository.ResetAsync(_mapper.Map<IEnumerable<StatCategory>>(request.StatCategories))
                                                                       .ConfigureAwait(false);

        await _statSkillsRepository.ResetAsync(_mapper.Map<IEnumerable<StatSkill>>(request.StatSkills))
                                                            .ConfigureAwait(false);

        await _statTypesRepository.ResetAsync(_mapper.Map<IEnumerable<StatType>>(request.StatTypes))
                                                         .ConfigureAwait(false);

        await PublishDataResetedEventAsync(cancellationToken).ConfigureAwait(false);
    }

    private Task PublishDataResetedEventAsync(CancellationToken cancellationToken)
    {
        DataResetedEvent @event = new();
        return _mediator.Publish(@event, cancellationToken);
    }
}