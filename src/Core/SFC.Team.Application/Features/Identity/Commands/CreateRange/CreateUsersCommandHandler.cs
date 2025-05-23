using AutoMapper;

using MediatR;

using SFC.Team.Application.Interfaces.Persistence.Repository.Identity.General;
using SFC.Team.Domain.Entities.Identity;
using SFC.Team.Domain.Events.Identity;

namespace SFC.Team.Application.Features.Identity.Commands.CreateRange;
public class CreateUsersCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IUserRepository userRepository) : IRequestHandler<CreateUsersCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Handle(CreateUsersCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<User> users = _mapper.Map<IEnumerable<User>>(request.Users);

        await _userRepository.AddRangeIfNotExistsAsync([.. users])
                                 .ConfigureAwait(false);

        UsersCreatedEvent @event = new(users);

        await _mediator.Publish(@event, cancellationToken)
                       .ConfigureAwait(false);
    }
}