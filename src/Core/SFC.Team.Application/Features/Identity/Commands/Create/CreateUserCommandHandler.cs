using AutoMapper;

using MediatR;

using SFC.Team.Application.Interfaces.Persistence.Repository.Identity.General;
using SFC.Team.Domain.Entities.Identity;

namespace SFC.Team.Application.Features.Identity.Commands.Create;
public class CreateUserCommandHandler(
    IMapper mapper,
    IUserRepository identityUserRepository) : IRequestHandler<CreateUserCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _identityUserRepository = identityUserRepository;

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user = _mapper.Map<User>(request.User);

        await _identityUserRepository.AddAsync(user)
                                     .ConfigureAwait(false);
    }
}