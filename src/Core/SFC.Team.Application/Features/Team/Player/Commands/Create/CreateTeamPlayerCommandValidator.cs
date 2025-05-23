using FluentValidation;

using SFC.Team.Application.Features.Team.Player.Common.Validators;
using SFC.Team.Application.Interfaces.Persistence.Repository.Player.General;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerCommandValidator : AbstractValidator<CreateTeamPlayerCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamPlayerRepository _teamPlayerRepository;

    public CreateTeamPlayerCommandValidator(
        ITeamRepository teamRepository,
        IPlayerRepository playerRepository,
        ITeamPlayerRepository teamPlayerRepository)
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
        _teamPlayerRepository = teamPlayerRepository;

        SetRulesForTeamPlayer();
    }

    private void SetRulesForTeamPlayer()
    {
        RuleFor(value => value.TeamPlayer)
            .SetValidator(new TeamPlayerValidator(_teamRepository, _playerRepository, _teamPlayerRepository));
    }
}