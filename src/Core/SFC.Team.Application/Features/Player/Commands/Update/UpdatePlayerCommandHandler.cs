using AutoMapper;

using MediatR;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Exceptions;
using SFC.Team.Application.Interfaces.Persistence.Repository.Player.General;

namespace SFC.Team.Application.Features.Player.Commands.Update;

public class UpdatePlayerCommandHandler(
    IMapper mapper,
    IPlayerRepository playerRepository) : IRequestHandler<UpdatePlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPlayerRepository _playerRepository = playerRepository;

    public async Task Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        PlayerEntity player = await _playerRepository.GetByIdAsync(request.Player.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.PlayerNotFound);

        PlayerEntity updatedPlayer = _mapper.Map(request.Player, player);

        await _playerRepository.UpdateAsync(updatedPlayer)
                               .ConfigureAwait(false);
    }
}