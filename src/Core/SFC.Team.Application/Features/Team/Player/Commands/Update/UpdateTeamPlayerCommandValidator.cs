using FluentValidation;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Exceptions;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Commands.Update;
public class UpdateTeamPlayerCommandValidator : AbstractValidator<UpdateTeamPlayerCommand>
{
    private readonly ITeamPlayerRepository _teamPlayerRepository;

    public UpdateTeamPlayerCommandValidator(ITeamPlayerRepository teamPlayerRepository)
    {
        _teamPlayerRepository = teamPlayerRepository;

        SetRulesForTeamPlayer();
    }

    private void SetRulesForTeamPlayer()
    {
        When(p => p.TeamPlayer.Status == (int)TeamPlayerStatusEnum.Removed, () =>
        {
            RuleFor(p => p.TeamPlayer.TeamComment!)
                .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
                .OverridePropertyName("TeamPlayer.Comment");

            RuleFor(value => value.TeamPlayer)
                .MustAsync(async (request, cancellation) => await _teamPlayerRepository.AnyAsync(request.TeamId, request.PlayerId).ConfigureAwait(true))
                .WithException(new NotFoundException(Localization.TeamPlayerNotFound));

            RuleFor(value => value.TeamPlayer)
                .MustAsync(async (request, cancellation) => !await IsPlayerAlreadyRemoved(request.TeamId, request.PlayerId).ConfigureAwait(false))
                .WithException(new ConflictException(Localization.TeamPlayerAlreadyRemoved));
        });
    }

    private async Task<bool> IsPlayerAlreadyRemoved(long teamId, long playerId)
    {
        TeamPlayer? teamPlayer = await _teamPlayerRepository.GetByIdAsync(teamId, playerId).ConfigureAwait(false);
        return teamPlayer?.StatusId == TeamPlayerStatusEnum.Removed;
    }
}