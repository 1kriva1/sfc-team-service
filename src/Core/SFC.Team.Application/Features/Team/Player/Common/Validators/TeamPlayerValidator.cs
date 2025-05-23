using FluentValidation;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Exceptions;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Features.Team.Player.Common.Dto;
using SFC.Team.Application.Interfaces.Persistence.Repository.Player.General;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Common.Validators;
public class TeamPlayerValidator : AbstractValidator<BaseTeamPlayerDto>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamPlayerRepository _teamPlayerRepository;

    public TeamPlayerValidator(ITeamRepository teamRepository, IPlayerRepository playerRepository, ITeamPlayerRepository teamPlayerRepository)
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
        _teamPlayerRepository = teamPlayerRepository;

        RuleFor(value => value)
            .MustAsync(async (request, cancellation) => await _teamRepository.AnyAsync(request.TeamId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.TeamNotFound));

        RuleFor(value => value)
            .MustAsync(async (request, cancellation) => await _playerRepository.AnyAsync(request.PlayerId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.PlayerNotFound));

        RuleFor(value => value)
            .MustAsync(async (request, cancellation) => !await _teamPlayerRepository.AnyAsync(request.TeamId, request.PlayerId).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.PlayerAlreadyInTeam));
    }
}