using AutoMapper;

using MediatR;

using SFC.Team.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Team.Domain.Entities.Request.Data;
using SFC.Team.Domain.Events.Request;

namespace SFC.Team.Application.Features.Request.Data.Commands.Reset;

public class ResetRequestDataCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IRequestStatusRepository requestStatusRepository) : IRequestHandler<ResetRequestDataCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IRequestStatusRepository _requestStatusRepository = requestStatusRepository;

    public async Task Handle(ResetRequestDataCommand request, CancellationToken cancellationToken)
    {
        await _requestStatusRepository
            .ResetAsync(_mapper.Map<IEnumerable<RequestStatus>>(request.RequestStatuses))
            .ConfigureAwait(false);

        await PublishDataResetedEventAsync(cancellationToken).ConfigureAwait(false);
    }

    private Task PublishDataResetedEventAsync(CancellationToken cancellationToken)
    {
        RequestDataResetedEvent @event = new();
        return _mediator.Publish(@event, cancellationToken);
    }
}