using FluentValidation;

using SFC.Team.Application.Features.Common.Validators.Common;
using SFC.Team.Application.Features.Common.Validators.Player;
using SFC.Team.Application.Features.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Team.Application.Features.Team.Player.Queries.Find;
public class GetTeamPlayersQueryValidator : AbstractValidator<GetTeamPlayersQuery>
{
    public GetTeamPlayersQueryValidator()
    {
        // pagination request filter
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetTeamPlayersViewModel, GetTeamPlayersFilterDto>());

        // player filter
        When(p => p?.Filter?.Player != null, () =>
        {
            RuleFor(command => command.Filter.Player!)
                .SetValidator(new PlayerFilterValidator());
        });
    }
}